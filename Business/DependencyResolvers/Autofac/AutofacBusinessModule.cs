using System;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;


namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<AuthorManager>().As<IAuthorService>().SingleInstance();
            builder.RegisterType<EfAuthorDal>().As<IAuthorDal>().SingleInstance();

            builder.RegisterType<BookManager>().As<IBookService>().SingleInstance();
            builder.RegisterType<EfBookDal>().As<IBookDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<PublisherManager>().As<IPublisherService>().SingleInstance();
            builder.RegisterType<EfPublisherDal>().As<IPublisherDal>().SingleInstance();

            builder.RegisterType<BookCopyManager>().As<IBookCopyService>().SingleInstance();
            builder.RegisterType<EfBookCopyDal>().As<IBookCopyDal>().SingleInstance();

            builder.RegisterType<BookCategoriesManager>().As<IBookCategoriesService>().SingleInstance();
            builder.RegisterType<EfBookCategoriesDal>().As<IBookCategoriesDal>().SingleInstance();

            builder.RegisterType<BorrowedBookManager>().As<IBorrowedBookService>().SingleInstance();
            builder.RegisterType<EfBorrowedBookDal>().As<IBorrowedBookDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<LibraryEmployeeManager>().As<ILibraryEmployeeService>().SingleInstance();
            builder.RegisterType<EfLibraryEmployeeDal>().As<ILibraryEmployeeDal>().SingleInstance();

            builder.RegisterType<MemberManager>().As<IMemberService>().SingleInstance();
            builder.RegisterType<EfMemberDal>().As<IMemberDal>().SingleInstance();

            builder.RegisterType<PublisherManager>().As<IPublisherService>().SingleInstance();
            builder.RegisterType<EfPublisherDal>().As<IPublisherDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
