using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumASPMVC.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_ThreadOne_ThreadOneId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Reply_Comment_CommentId",
                table: "Reply");

            migrationBuilder.DropForeignKey(
                name: "FK_ThreadOne_Topics_TopicId",
                table: "ThreadOne");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ThreadOne",
                table: "ThreadOne");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reply",
                table: "Reply");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "ThreadOne",
                newName: "ThreadOnes");

            migrationBuilder.RenameTable(
                name: "Reply",
                newName: "Replies");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_ThreadOne_TopicId",
                table: "ThreadOnes",
                newName: "IX_ThreadOnes_TopicId");

            migrationBuilder.RenameIndex(
                name: "IX_Reply_CommentId",
                table: "Replies",
                newName: "IX_Replies_CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_ThreadOneId",
                table: "Comments",
                newName: "IX_Comments_ThreadOneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThreadOnes",
                table: "ThreadOnes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Replies",
                table: "Replies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ThreadOnes_ThreadOneId",
                table: "Comments",
                column: "ThreadOneId",
                principalTable: "ThreadOnes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Comments_CommentId",
                table: "Replies",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThreadOnes_Topics_TopicId",
                table: "ThreadOnes",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ThreadOnes_ThreadOneId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Comments_CommentId",
                table: "Replies");

            migrationBuilder.DropForeignKey(
                name: "FK_ThreadOnes_Topics_TopicId",
                table: "ThreadOnes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ThreadOnes",
                table: "ThreadOnes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Replies",
                table: "Replies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "ThreadOnes",
                newName: "ThreadOne");

            migrationBuilder.RenameTable(
                name: "Replies",
                newName: "Reply");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_ThreadOnes_TopicId",
                table: "ThreadOne",
                newName: "IX_ThreadOne_TopicId");

            migrationBuilder.RenameIndex(
                name: "IX_Replies_CommentId",
                table: "Reply",
                newName: "IX_Reply_CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ThreadOneId",
                table: "Comment",
                newName: "IX_Comment_ThreadOneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThreadOne",
                table: "ThreadOne",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reply",
                table: "Reply",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_ThreadOne_ThreadOneId",
                table: "Comment",
                column: "ThreadOneId",
                principalTable: "ThreadOne",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reply_Comment_CommentId",
                table: "Reply",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThreadOne_Topics_TopicId",
                table: "ThreadOne",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
