namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tewasf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Endroits",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        pos_lat = c.Double(nullable: false),
                        pos_lon = c.Double(nullable: false),
                        pos_zapAccessible = c.Boolean(nullable: false),
                        Categorie = c.Int(nullable: false),
                        Prix = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Evenements",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        MUNID = c.Int(nullable: false),
                        DT01 = c.String(),
                        DT02 = c.String(),
                        HR01 = c.String(),
                        HR02 = c.String(),
                        HOR = c.String(),
                        TITRE = c.String(),
                        TEL1 = c.String(),
                        DESCRIP = c.String(),
                        URL = c.String(),
                        CATEG = c.String(),
                        LOC = c.String(),
                        AD_NO = c.String(),
                        AD_GEN = c.String(),
                        AD_LIEN = c.String(),
                        AD_MUN = c.String(),
                        CO = c.String(),
                        EndroitId = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Endroits", t => t.EndroitId, cascadeDelete: true)
                .Index(t => t.EndroitId);
            
            CreateTable(
                "dbo.Parcs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        NOM = c.String(),
                        x = c.String(),
                        y = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.PisteCyclables",
                c => new
                    {
                        PISTECYCLABLE_IDG = c.String(nullable: false, maxLength: 128),
                        NOMVILLE = c.String(),
                        NOMDESTINATIONSHERBROOKE = c.String(),
                        NOMMTQ = c.String(),
                        REMARQUE = c.String(),
                        LARGEUR = c.String(),
                        TYPE_resolved = c.String(),
                        TYPEREVETEMENT_resolved = c.String(),
                        TYPEMTQ1_resolved = c.String(),
                        TYPEMTQ2_resolved = c.String(),
                        METHODECAPTAGEID_resolved = c.String(),
                        Shape_len00 = c.String(),
                    })
                .PrimaryKey(t => t.PISTECYCLABLE_IDG);
            
            CreateTable(
                "dbo.Zaps",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        name = c.String(),
                        description = c.String(),
                        civic_number = c.String(),
                        street_name = c.String(),
                        city = c.String(),
                        province = c.String(),
                        country = c.String(),
                        postal_code = c.String(),
                        public_phone_number = c.String(),
                        public_email = c.String(),
                        latitude = c.String(),
                        longitude = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evenements", "EndroitId", "dbo.Endroits");
            DropIndex("dbo.Evenements", new[] { "EndroitId" });
            DropTable("dbo.Zaps");
            DropTable("dbo.PisteCyclables");
            DropTable("dbo.Parcs");
            DropTable("dbo.Evenements");
            DropTable("dbo.Endroits");
        }
    }
}
