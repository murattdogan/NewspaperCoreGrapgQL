﻿using GraphQL.Types;
using NewspaaperCoreGrapgQL.Business.Abstract;
using NewspaaperCoreGrapgQL.Business.GraphModels.Types.Category;

namespace NewspaaperCoreGrapgQL.Business.GraphModels.Queries
{

    public class CategoryQuery : ObjectGraphType
    {
        public CategoryQuery(ICategoryService categoryRepository)
        {
            Field<ListGraphType<CategoryType>>(
                "categories",
                resolve: context => categoryRepository.GetAll());
             
            Field<CategoryType>(
                "category",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => categoryRepository.GetById(context.GetArgument<int>("id"))
                );
        }
    }
}
