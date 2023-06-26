﻿global using System.Net;
global using System.Runtime.Serialization;
global using System.Text;
global using Ardalis.ApiEndpoints;
global using BuildingBlocks.Repository.Data;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.Filters;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;
global using School.Api.DI;
global using School.Api.Exceptions;
global using School.Api.Filters;
global using School.Core.Data;
global using School.Core.Dtos;
global using School.Core.Repositories;
global using School.Core.Services;
global using Serilog;
global using Swashbuckle.AspNetCore.Annotations;
global using Swashbuckle.AspNetCore.SwaggerGen;

