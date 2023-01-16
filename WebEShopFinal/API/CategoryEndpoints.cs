using Microsoft.EntityFrameworkCore;
using WebEShopFinal.Data;
using WebEShopFinal.Data.Repositories;
using WebEShopFinal.Models;
namespace WebEShopFinal.API;

public static class CategoryEndpoints
{
    public static void MapCategoryEndpoints (this IEndpointRouteBuilder routes)
    {
        //var category = new CategoryRepository(ApplicationDbContext db);
        
        // GET ALL categories --- SELECT / READ
        routes.MapGet("/api/Categories", async (ApplicationDbContext db) =>
        {
            return await new CategoryRepository(db).GetAll();
        })
        .WithName("GetAllCategories")
        .Produces<List<Category>>(StatusCodes.Status200OK);

        // GET a category --- SELECT WHERE / READ
        routes.MapGet("/api/Category/{id}", async (int Id, ApplicationDbContext db) =>
        {
            return await new CategoryRepository(db).Get(Id)
                is Category model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetCategoryById")
        .Produces<Category>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        // UPDATE a category --- UPDATE 
        routes.MapPut("/api/Category/{id}", async (int Id, Category category, ApplicationDbContext db) =>
        {
            var foundModel = await new CategoryRepository(db).Update(Id, category);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            
            db.Update(category);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateCategory")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        // CREATE a category --- CREATE
        routes.MapPost("/api/Category/", async (Category category, ApplicationDbContext db) =>
        {
            await new CategoryRepository(db).Add(category);
            await db.SaveChangesAsync();
            return Results.Created($"/Categorys/{category.Id}", category);
        })
        .WithName("CreateCategory")
        .Produces<Category>(StatusCodes.Status201Created);

        // DELETE a category --- DELETE
        routes.MapDelete("/api/Category/{id}", async (int Id, ApplicationDbContext db) =>
        {
            if (await new CategoryRepository(db).Get(Id) is Category category)
            {
                new CategoryRepository(db).Remove(Id);
                await db.SaveChangesAsync();
                return Results.Ok(category);
            }

            return Results.NotFound();
        })
        .WithName("DeleteCategory")
        .Produces<Category>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
