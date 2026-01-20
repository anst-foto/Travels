using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Travels.BLL;
using Travels.DAL;
using Travels.Models;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("Test");
var connectionString = "Server=127.0.0.1;Port=5432;Database=travels_db;User Id=admin;Password=1234;Search Path=test;";
var app = builder.Build();

var repo = new PointRepositoryPostgres(connectionString);
var worker = new PointWorkerBase(repo);
const string path = "/api/v1/points";
app.MapGet($"{path}/", () => worker.GetPointsAsync());
app.MapGet($"{path}/{{id:guid}}", async (Guid id) => await worker.GetPointByIdAsync(id));
app.MapPost($"{path}/", async (Point point) => await worker.AddPointAsync(point));
app.MapPut($"{path}/{{id:guid}}", async (Guid id, Point point) => await worker.UpdatePointAsync(point));
app.MapDelete($"{path}/{{id:guid}}", async (Guid id) => await worker.DeletePointAsync(id));

await app.RunAsync();
