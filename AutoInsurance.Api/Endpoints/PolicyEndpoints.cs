using Microsoft.EntityFrameworkCore;
using AutoInsurance.Domain.Entities;
using Microsoft.AspNetCore.OpenApi;
using AutoMapper;
using AutoInsurance.Application.DTOs.Policy;
using AutoInsurance.Infrastructure;
using AutoInsurance.Application.Services;
namespace AutoInsurance.Api.Endpoints;

public static class PolicyEndpoints
{
    public static void MapPolicyEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Policy").WithTags(nameof(Policy));

        group.MapGet("/", async (AutoInsuranceDbContext db, IMapper mapper) =>
        {
            var policies = await db.Policies.ToListAsync();
            var data = mapper.Map<List<PolicyDto>>(policies);
            return data;
        })
        .WithName("GetAllPolicies")
        .WithOpenApi()
        .Produces<List<PolicyDto>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async  (int id, AutoInsuranceDbContext db, IMapper mapper) =>
        {
            return await db.Policies.FindAsync(id)
                is Policy model
                    ? Results.Ok(mapper.Map<PolicyDto>(model))
                    : Results.NotFound();
        })
        .WithName("GetPolicyById")
        .WithOpenApi()
        .Produces<PolicyDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", async  (int id, PolicyDto policyDto, AutoInsuranceDbContext db, IMapper mapper) =>
        {
            var foundModel = await db.Policies.FindAsync(id);

            if (foundModel == null)
            {
                return Results.NotFound();
            }
            mapper.Map(policyDto, foundModel);
            await db.SaveChangesAsync();
            return Results.NoContent();
        })
        .WithName("UpdatePolicy")
        .WithOpenApi()
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (CreatePolicyDto policyDto, PolicyService policyService, AutoInsuranceDbContext db, IMapper mapper) =>
        {
            var createdPolicy = await policyService.CreateAsync(policyDto);
            return Results.Created($"/api/policies/{createdPolicy.Id}", createdPolicy);
        })
        .WithName("CreatePolicy")
        .WithOpenApi()
        .Produces<Policy>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async  (int id, AutoInsuranceDbContext db, IMapper mapper) =>
        {
            if (await db.Policies.FindAsync(id) is Policy policy)
            {
                db.Policies.Remove(policy);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();
        })
        .WithName("DeletePolicy")
        .WithOpenApi()
        .Produces<Policy>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
