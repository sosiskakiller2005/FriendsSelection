﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FriendsSelection.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TeammateSearchDbEntities : DbContext
    {
        public TeammateSearchDbEntities()
            : base("name=TeammateSearchDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Developer> Developer { get; set; }
        public virtual DbSet<Friend> Friend { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<GameTag> GameTag { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Requests> Requests { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<Tournament> Tournament { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserGames> UserGames { get; set; }
        public virtual DbSet<UserTournament> UserTournament { get; set; }
    }
}
