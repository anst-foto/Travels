using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Travels.BLL;
using Travels.DAL;
using Travels.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var app = builder.Build();

var worker = new PointWorkerBase(new PointRepositoryPostgres(connectionString));

const string path = "/api/v1/points";
app.MapGet($"{path}/", () => worker.GetPointsAsync());
app.MapGet($"{path}/{{id:guid}}", async (Guid id) => await worker.GetPointByIdAsync(id));
app.MapPost($"{path}/", async (Point point) => await worker.AddPointAsync(point));
app.MapPut($"{path}/{{id:guid}}", async (Guid id, Point point) => await worker.UpdatePointAsync(point));
app.MapDelete($"{path}/{{id:guid}}", async (Guid id) => await worker.DeletePointAsync(id));

await app.RunAsync();
