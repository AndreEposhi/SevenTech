using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SevenTech.Application.Commands;
using SevenTech.Application.Handlers;
using SevenTech.Application.Queries;
using SevenTech.Application.Services;
using SevenTech.Application.ViewModels;
using SevenTech.Domain.Repositories;
using SevenTech.Domain.UnitOfWork;
using SevenTech.Infra.Data;
using SevenTech.Infra.Repositories;
using System;
using System.Collections.Generic;

namespace SevenTech.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection Configure(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(connection));

            var assembly = AppDomain.CurrentDomain.Load("SevenTech.Application");

            //Data
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            //Commands/Queries
            services.AddScoped<IRequestHandler<AdicionaClienteCommand, ValidationResult>, AdicionaClienteHandler>();
            services.AddScoped<IRequestHandler<AtualizaClienteCommand, ValidationResult>, AtualizaClienteHandler>();
            services.AddScoped<IRequestHandler<RemoveClienteCommand, ValidationResult>, RemoveClienteHandler>();
            services.AddScoped<IRequestHandler<ListaTodosClientesQuery, IEnumerable<ClienteViewModel>>, ListaTodosClientesHandler>();
            services.AddScoped<IRequestHandler<ObterClientePorIdQuery, ClienteViewModel>, ObterClientePorIdHandler>();
            services.AddMediatR(assembly);

            //Service
            services.AddScoped<ICepService, CepService>();

            return services;
        }
    }
}