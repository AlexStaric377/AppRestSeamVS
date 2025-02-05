using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppRestSeam.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Windows;

/// "������������ ���������� ����� ���������� ������-SEAM" 
/// ��������� ���������� ��������� �������� ���.+380674012840, mail staric377@gmail.com
/// ��������� ������� ������ �� �� � ���� front ��  Back ������������

namespace AppRestSeam
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

            
            //// ������������� �������� ������
            //string connection = "Server=(localdb)\\mssqllocaldb;Database=d:\\dbseam;Trusted_Connection=True;";
            services.AddDbContext<DbContextSeam>(options => options.UseSqlServer(Program.connection));
            //services.AddControllersWithViews();
            services.AddControllers();
            //    .AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling =
            //    Newtonsoft.Json.ReferenceLoopHandling.Ignore);
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
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = ApiControllerDoctor}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = ApiControllerComplaint}/{action}/{id?}/{*catchall}"); 
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = ControllerListGroupDetail }/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = FeatureController}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = DetailingController}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = GrDetalingController}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = GroupQualificationController }/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = QualificationController }/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = DiagnozController}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = InterviewController}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = ContentInterviewController}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = CompletedInterviewController}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = RecommendationController}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = DependencyDiagnozController}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = PacientController}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = ColectionInterviewController}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = MedicalInstitutionController}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = IcdController}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = LanguageUIController}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = PacientMapAnalizController}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = LifePacientController}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = LifeDoctorController}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = AccountUserController}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = NsiStatusUserController}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = ControllerAdmissionPatients}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = RegistrationAppointmentController}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = PacientAnalizKroviController}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = PacientAnalizUrineController}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = VisitingDaysController}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = UnLoadController}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = ApiControllerVisitingDays}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = SobController}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = GrupDiagnozController}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = MedGrupDiagnozController}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = LikarGrupDiagnozController}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = ControllerPayment}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = ControllerPrice}/{action}/{id?}/{*catchall}");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller = ControllerStatusMedZaklad}/{action}/{id?}/{*catchall}");
            });
        }
    }

    //    ����������� ������������� ����� ������� HTTP

    //HTTP ���������� ��������� ���� ������� ��� �������� ������� ��������� ���������� �� ���������.���� REST ���������� ����� �� ���������� ������������ ��� ��������� HTTP-����, ����� ������ ������� ��������� ��������� �����.����� ����������� ������ ����� ������� HTTP:

    //200 OK � ��� ����� �� �������� GET, PUT, PATCH ��� DELETE.���� ��� ����� ������������ ��� POST, ������� �� �������� � ��������.
    //201 Created � ���� ��� ��������� �������� ������� �� POST, ������� �������� � ��������.
    //204 ��� �����������. ��� ����� �� �������� ������, ������� �� ����� ���������� ���� (��������, ������ DELETE)
    //304 Not Modified � ����������� ���� ��� ���������, ����� ��������� HTTP-����������� ��������� � ������
    //400 Bad Request � ���� ��� ��������� ���������, ��� ������ �������, ��������, ���� ���� �� ����� ���� ����������������
    //401 Unauthorized � ���� �� ������� ��� ��������������� ������ ��������������.����� ������� ������������ ����������� ���� auth, ���� ���������� ������������ �� ��������
    //403 Forbidden � ����� �������������� ������ �������, �� ������������������� ������������ �� ����� ������� � �������
    //404 Not found � ���� ������������� �������������� ������
    //405 Method Not Allowed � ����� ������������� HTTP-�����, ������� �� �������� ��� �������������������� ������������
    //410 Gone � ���� ��� ��������� ���������, ��� ������ � ���� �������� ����� ������ �� ��������.������� � �������� ��������� ������ ��� ������ ������ API
    //415 Unsupported Media Type.���� � �������� ����� ������� ��� ������ ������������ ��� �����������
    //422 Unprocessable Entity � ������������ ��� �������� ������
    //429 Too Many Requests � ����� ������ ����������� ��-�� ����������� ��������
//    � ��������� HTTP ������� ����� 70 ������ �����.������� ����� �������� ������������� ���� �� ��������.

//200 � OK � �������� ������. ���� �������� ���� ��������� �����-���� ������, �� ��� ��������� � ��������� �/��� ���� ���������.
//    201 � OK � � ���������� ��������� ���������� ������� ��� ������ ����� ������.
//    204 � OK � ������ ������� �����.
//    304 � Not Modified � ������ ����� ������������ ������ �� ����.
//400 � Bad Request � ������ ���������� ��� �� ����� ���� ���������.
//    401 � Unauthorized � ������ ������� �������������� ������������.
//403 � Forbidden � ������ ����� ������, �� ������������ ��� ���������� ��� ������ ��������.
//    404 � Not found � ������ �� ������.
//    500 � Internal Server Error � ������������ API ������ ��������� �������� ����� ������.
}
