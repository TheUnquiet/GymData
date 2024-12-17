using Assembly.Data.Data;
using Assembly.Data.Repositories;
using Assembly.Domain.Interfaces;
using Assembly.Domain.Managers;
using Microsoft.EntityFrameworkCore;

namespace Assembly.Rest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Database
            var cs = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<GymContext>(options => options.UseSqlServer(cs));

            // Repos
            builder.Services.AddScoped<IMemberRepository, MemberRepository>();
            builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
            builder.Services.AddScoped<ITimeSlotRepository, TimeSlotRepository>();

            // Managers
            builder.Services.AddScoped<MemberManager>();
            builder.Services.AddScoped<EquipmentManager>();
            builder.Services.AddScoped<ReservationManager>();
            builder.Services.AddScoped<TimeSlotManager>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
