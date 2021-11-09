namespace EduApp.Core.Repositories
{
    public interface IUnitOfWork
    {
        IAccountRepository AccountRepository { get; }
        IRoleRepository RoleRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ICommentRepository CommentRepository { get; }
        ICourseRepository CourseRepository { get; }
        IHomeworkRepository HomeworkRepository { get; }
        ILessonRepository LessonRepository { get; }
        IOrderRepository OrderRepository { get; }
        IReviewRepository ReviewRepository { get; }
        IUserInfoRepository UserInfoRepository { get; }

        void Commit();
    }
}
