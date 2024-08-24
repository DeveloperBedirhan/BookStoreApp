using Entities.Models;
using Services.Contracts;
using Repositories.Contracts;
using Entities.Exceptions;
using Entities.DataTransferObjects;
using AutoMapper;
using Entities.RequestFeatures;
using Entities.LinkModels;

namespace Services
{
    public class BookManager : IBookService
    {
        private readonly ICategoryService _categoryService;
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        private readonly IBookLinks _bookLinks;

        public BookManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper, 
            IBookLinks bookLinks, ICategoryService categoryService)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
            _bookLinks = bookLinks;
            _categoryService = categoryService;
        }

        public async Task<BookDto> CreateOneBookAsync(BookDtoForInsertion bookDto)
        {
            var category = await _categoryService.GetOneCategoryByIdAsync(bookDto.CategoryId, false);

            var entity = _mapper.Map<Book>(bookDto);
            //entity.CategoryId = bookDto.CategoryId;
            _manager.Book.CreateOneBook(entity);
            await _manager.SaveAsync();
            return _mapper.Map<BookDto>(entity);
        }

        public async Task DeleteOneBookAsync(int id, bool trackChanges)
        {
            var entity = await GetOneBookByIdAndCheckExist(id, trackChanges);
            _manager.Book.DeleteOneBook(entity);
            await _manager.SaveAsync();
        }

        public async Task<(LinkResponse linkResponse, MetaData metaData)> 
            GetAllBooksAsync(LinkParameters linkParameters, bool trackChanges)
        {
            if(!linkParameters.BookParameters.ValidPriceRange)
                throw new PriceOutOfRangeBadRequestException();
            
            var booksWithMetaData = await _manager.Book.GetAllBooksAsync(linkParameters.BookParameters, trackChanges);
            var booksDto = _mapper.Map<IEnumerable<BookDto>>(booksWithMetaData);
            
            var links = _bookLinks.TryGenerateLinks(booksDto, 
                linkParameters.BookParameters.Fields, linkParameters.HttpContext);

            return (linkResponse: links, metaData: booksWithMetaData.MetaData);
        }

        public async Task<List<Book>> GetAllBooksAsync(bool trackChanges) =>
            await _manager.Book.GetAllBooksAsync(trackChanges);


        public async Task<IEnumerable<Book>> GetAllBooksWithDetailsAsync(bool trackChanges) =>
            await _manager.Book.GetAllBooksWithDetailsAsync(trackChanges);


        public async Task<BookDto> GetOneBookByIdAsync(int id, bool trackChanges)
        {
            var book = await GetOneBookByIdAndCheckExist(id, trackChanges);
            return _mapper.Map<BookDto>(book);
        }

        public async Task<(BookDtoForUpdate bookDtoForUpdate, Book book)> GetOneBookForPatchAsync(int id, bool trackChanges)
        {
            var book = await GetOneBookByIdAndCheckExist(id, trackChanges);
            var bookDtoForUpdate = _mapper.Map<BookDtoForUpdate>(book);
            return (bookDtoForUpdate, book);
        }

        public async Task SaveChangesForPatchAsync(BookDtoForUpdate bookDtoForUpdate, Book book)
        {
            _mapper.Map(bookDtoForUpdate, book);
            await _manager.SaveAsync();
        }

        public async Task UpdateOneBookAsync(int id, BookDtoForUpdate bookDto, bool trackChanges)
        {
            var entity = await GetOneBookByIdAndCheckExist(id, trackChanges);
            entity = _mapper.Map<Book>(bookDto);
            _manager.Book.Update(entity);
            await _manager.SaveAsync();
        }

        private async Task<Book> GetOneBookByIdAndCheckExist(int id, bool trackChanges)
        {
            //check entity
            var entity = await _manager.Book.GetOneBookByIdAsync(id, trackChanges);
            
            if (entity is null)
                throw new BookNotFoundException(id);

            return entity;
        }
    }
}
