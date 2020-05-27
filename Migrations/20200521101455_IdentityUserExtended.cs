﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrandPeltekHotel.Migrations
{
    public partial class IdentityUserExtended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
              name: "LastName",
              table: "AspNetUsers",
              maxLength: 256,
              nullable: true);


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
               name: "LastName",
               table: "AspNetUsers");

        }
    }
}
