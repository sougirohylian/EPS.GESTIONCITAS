using AutoMapper;
using EPS.GESTIONCITAS.PERSONAS.DATAACCESS.Model;
using EPS.GESTIONCITAS.PERSONAS.LOGIC.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EPS.GESTIONCITAS.PERSONAS.WebApiTest.Services
{
    public  class PersonasServicesTest
    {
        private DATAACCESS.Model.PERSONAS Personas;
        private IMapper mapper;
        [SetUp]
        public void Setup()
        {
            mapper = Substitute.For<IMapper>();
            Personas = new DATAACCESS.Model.PERSONAS()
            {
                ID_PERSONA = 1,
                NOMBRES = "Test",
                APELLIDOS = "Auto 1",
                FECHA_NACIMIENTO = DateTime.Now,
                ID_TIPO_PERSONA = 1,
                CEDULA = 11111111
            };
        }
        class EntitiContext : DbContext
        {
            public EntitiContext(DbContextOptions options) : base(options)
            {
            }
            public DbSet<DATAACCESS.Model.PERSONAS> Orders { get; set; }
        }
        private IServiceProvider CreateContext(string nameDB)
        {
            var services = new ServiceCollection();
            var options = new DbContextOptionsBuilder()
            .UseSqlServer(@"Server=ASWALD\\MSSQLLOCALDB;initial catalog=EPS.GESTIONCITAS.PERSONAS;integrated security=True;encrypt=False;MultipleActiveResultSets=True;App=EntityFramework&quot;")
            .Options;
            services
                .AddSingleton(options)
                .AddScoped<EntitiContext>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            services.AddDbContext<EntitiContext>(options => options.UseInMemoryDatabase(databaseName: nameDB),
                ServiceLifetime.Scoped,
                ServiceLifetime.Scoped);
            return services.BuildServiceProvider();
        }
        [Test]
        [TestCase(HttpStatusCode.OK)]
        [TestCase(HttpStatusCode.InternalServerError)]
        public async Task When_add_person_services(HttpStatusCode code)
        {
            //Arrange
            var nameDb = Guid.NewGuid().ToString();
            var servicesProvider = CreateContext(nameDb);

            var db = servicesProvider.GetService<EntitiContext>();
            db.Add(Personas);
            //Act
            if (code == HttpStatusCode.OK)
                mapper.Map<DATAACCESS.Model.PERSONAS>(Personas).ReturnsForAnyArgs(Personas);
            else
                mapper.Map<DATAACCESS.Model.PERSONAS>(Personas).ThrowsForAnyArgs(x => { throw new Exception(); });
            //PersonasServices personasServices = new PersonasServices(db, mapper);
            //Assert
            
        }
    }
}
