﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;

namespace Data
{
  /// <summary>
  /// [[SINGLETON]]
  /// </summary>
  public class TestContext : DbContext
  {
    public static TestContext DB { get; private set; }

    public DbSet<Usuario> Usuarios { get; set; }

    public DbSet<Perfil> Perfiles { get; set; }

    static TestContext()
    {
      DB = new TestContext();
    }

    private TestContext()
    {
      //  crear writer para log de eventos
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Configurations.Add(new ConfiguracionUsuario());
      modelBuilder.Configurations.Add(new ConfiguracionPerfil());
    }
  }

  public class ConfiguracionUsuario : EntityTypeConfiguration<Usuario>
  {
    public ConfiguracionUsuario()
    {
      this.HasKey(usr => usr.Login);

      this.Property(usr => usr.LastLogin)
        .HasColumnName("FechaUltimoLogin");

      this.HasRequired(usr => usr.Perfil)
        .WithMany()
        .Map(cfg => cfg.MapKey("ID_Perfil"));
    }
  }

  public class ConfiguracionPerfil : EntityTypeConfiguration<Perfil>
  {
    public ConfiguracionPerfil()
    {
      ToTable("Perfiles");    //  evitamos Perfils

      this.HasKey(per => per.IDPerfil);
      this.Property(per => per.IDPerfil)
        .HasColumnName("ID_Perfil");
    }
  }
}
