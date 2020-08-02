using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Accion.Business.CQRS;
using Accion.Business.Interface;
using Accion.Business.Logic;
using Accion.Business.Saga;
using Accion.Model.Business;
using Accion.Model.Request;
using Accion.Model.Response;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Accion.EmployeeMgmt
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<PermanentSalary>();
            services.AddSingleton<ContractSalary>();
            services.AddSingleton<ISaga<AddEmpRequest, EmpCrudResp>, AddEmpSaga>();
            services.AddSingleton<ISaga<DeleteEmpReq, EmpCrudResp>, DeleteEmpSaga>();
            services.AddSingleton<ISaga<SearchEmpReq, SearchEmpResp>, EmpSearchSaga>();
            services.AddSingleton<ISaga<SalaryReq, EmpSalaryResp>, ProcessSalarySaga>();
            services.AddSingleton<ISaga<UpdateEmpReq, EmpCrudResp>, UpdateEmpSaga>();
            services.AddSingleton<ICQRS<Guid, bool>, DeleteEmployee>();
            services.AddSingleton<ICQRS<SearchEmpReq, IEnumerable<EmpModel>>, SearchEmployee>();
            services.AddSingleton<ICQRS<EmpModel, bool>, UpdateEmployee>();

            services.AddTransient<Func<EmployeeType, ISalaryProcess>>((serviceProvider) => key =>
            {
                return key switch
                {
                    EmployeeType.Contract => serviceProvider.GetService<ContractSalary>(),
                    EmployeeType.Permanent => serviceProvider.GetService<PermanentSalary>(),
                    _ => null,
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
