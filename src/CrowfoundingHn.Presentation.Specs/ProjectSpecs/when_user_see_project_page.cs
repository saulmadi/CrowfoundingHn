using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowfoundingHn.Common;
using CrowfoundingHn.Presentation.Api.Requests;
using CrowfoundingHn.Projects.Application.Commands;
using CrowfoundingHn.Projects.Domain;
using FizzWare.NBuilder;
using Machine.Specifications;
using MongoDB.Driver;
using Nancy;
using Nancy.Testing;

namespace CrowfoundingHn.Presentation.Specs.ProjectSpecs
{
    class when_user_see_project_page
    {
        static Browser _browser;

        private static ProjectQueryRequest _projectQueryRequest = new ProjectQueryRequest();
        private static IProjectRepositoryReadOnly _projectRepositoryReadOnly = new ProjectRepositoryReadOnly();
        private static ProjectResponse _projectResponse;
        private static MongoCollection _collection;
        private static Project _project;

        private Establish context = () => 
        {
            _browser  = new Browser(
                x =>
                {

                    x.Module<ProjectQueryModule>();
                    x.Dependency(_projectRepositoryReadOnly);
                }
                );

            _projectQueryRequest = Builder<ProjectQueryRequest>.CreateNew().Build();

        };


    }

    public class ProjectResponse
    {
    }

    public class ProjectRepositoryReadOnly : IProjectRepositoryReadOnly
    {
    }

    public class ProjectQueryModule:NancyModule
    {
    }

    public interface IProjectRepositoryReadOnly
    {
    }

    public class ProjectQueryRequest
    {
    }
}
