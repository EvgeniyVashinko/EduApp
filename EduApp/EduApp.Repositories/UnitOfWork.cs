using EduApp.Core.Repositories;
using EduApp.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace EduApp.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextOptions _options;
        private AppContext _context;

        private AccountRepository _accountRepository;
        private RoleRepository _roleRepository;
        private UserInfoRepository _userInfoRepository;
        private CategoryRepository _categoryRepository;
        private CommentRepository _commentRepository;
        private CourseRepository _courseRepository;
        private HomeworkRepository _homeworkRepository;
        private LessonRepository _lessonRepository;
        private OrderRepository _orderRepository;
        private ReviewRepository _reviewRepository;

        private AppContext Context => _context ??= new AppContext(_options);

        public IAccountRepository AccountRepository => _accountRepository ??= new AccountRepository(Context);

        public IRoleRepository RoleRepository => _roleRepository ??= new RoleRepository(Context);

        public IUserInfoRepository UserInfoRepository => _userInfoRepository ??= new UserInfoRepository(Context);

        public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(Context);

        public ICommentRepository CommentRepository => _commentRepository ??= new CommentRepository(Context);

        public ICourseRepository CourseRepository => _courseRepository ??= new CourseRepository(Context);

        public IHomeworkRepository HomeworkRepository => _homeworkRepository ??= new HomeworkRepository(Context);

        public ILessonRepository LessonRepository => _lessonRepository ??= new LessonRepository(Context);

        public IOrderRepository OrderRepository => _orderRepository ??= new OrderRepository(Context);

        public IReviewRepository ReviewRepository => _reviewRepository ??= new ReviewRepository(Context);


        public UnitOfWork(IOptions<UnitOfWorkOptions> accessor) : this(accessor.Value)
        {
        }

        public UnitOfWork(UnitOfWorkOptions options)
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(options.ConnectionString, x => x.CommandTimeout(options.CommandTimeout));
            _options = optionsBuilder.Options;
        }

        public void Commit()
        {
            if (_context == null)
            {
                return;
            }

            if (_isDisposed)
            {
                throw new ObjectDisposedException("UnitOfWork");
            }

            Context.SaveChanges();
        }

        private bool _isDisposed;

        public void Dispose()
        {
            if (_context == null)
            {
                return;
            }

            if (!_isDisposed)
            {
                _context.Dispose();
            }

            _isDisposed = true;
        }
    }
}
