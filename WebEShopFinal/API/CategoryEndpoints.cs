using Microsoft.EntityFrameworkCore;
using WebEShopFinal.Data;
using WebEShopFinal.Models;
using WebEShopFinal.Services;

namespace WebEShopFinal.API;

public static class CategoryEndpoints
{
    public static void MapCategoryEndpoints (this IEndpointRouteBuilder routes)
    {
        // GET ALL categories --- SELECT / READ
        routes.MapGet("/api/Categories", async (ICategoryService service) =>
        {
            return await service.GetCategories();
        })
        .WithName("GetAllCategories")
        .Produces<List<Category>>(StatusCodes.Status200OK);

        // GET a category --- SELECT WHERE / READ
        routes.MapGet("/api/Category/{Id}", async (int Id, ICategoryService service) =>
        {
            return await service.GetCategory(Id)
                is Category model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetCategoryById")
        .Produces<Category>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        // UPDATE a category --- UPDATE 
        routes.MapPut("/api/Category/{Id}", async (int Id, Category category, ICategoryService service) =>
        {
            category.Id = Id;
            return Results.Text($"{await service.AddOrUpdateCategory(category)}");
        })
        .WithName("UpdateCategory")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        // CREATE a category --- CREATE
        routes.MapPost("/api/Category/", async (Category category, ICategoryService service) =>
        {
            var dbCategory = await service.AddOrUpdateCategory(category);
            if(dbCategory != null)
            {
                return Results.Created($"/Categories/{dbCategory.Id}", dbCategory);
            }
            return Results.NotFound();
        })
        .WithName("CreateCategory")
        .Produces<Category>(StatusCodes.Status201Created);

        // DELETE a category --- DELETE
        routes.MapDelete("/api/Category/{Id}", async (int Id, ICategoryService service) =>
        {
            return Results.Text($"{await service.RemoveCategory(Id)}");
        })
        .WithName("DeleteCategory")
        .Produces<Category>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
