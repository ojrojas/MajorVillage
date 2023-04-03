global using System.Net;
global using System.Runtime.Serialization;
global using System.Text;
global using Api.DI;
global using Api.Exceptions;
global using Api.Filters;
global using Ardalis.ApiEndpoints;
global using BuildingBlocks.Repository.Data;
global using Core.Data;
global using Core.Dtos;
global using Core.Interfaces;
global using Core.Repositories;
global using Core.Services;
global using Infraestructure.Encrypt;
global using Infraestructure.Token;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.Filters;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;
global using Serilog;
global using Swashbuckle.AspNetCore.Annotations;


