namespace Digital_Library.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuestions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        Text = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        QuestionnarieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questionnaries", t => t.QuestionnarieId, cascadeDelete: true)
                .Index(t => t.QuestionnarieId);
            
            CreateTable(
                "dbo.AnswerVariants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questionnaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "QuestionnarieId", "dbo.Questionnaries");
            DropForeignKey("dbo.AnswerVariants", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropIndex("dbo.AnswerVariants", new[] { "QuestionId" });
            DropIndex("dbo.Questions", new[] { "QuestionnarieId" });
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropTable("dbo.Questionnaries");
            DropTable("dbo.AnswerVariants");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
