using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class message2_tablefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message2_Writers_MessageReceiverID",
                table: "Message2");

            migrationBuilder.DropForeignKey(
                name: "FK_Message2_Writers_MessageSenderID",
                table: "Message2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message2",
                table: "Message2");

            migrationBuilder.RenameTable(
                name: "Message2",
                newName: "Messages2");

            migrationBuilder.RenameIndex(
                name: "IX_Message2_MessageSenderID",
                table: "Messages2",
                newName: "IX_Messages2_MessageSenderID");

            migrationBuilder.RenameIndex(
                name: "IX_Message2_MessageReceiverID",
                table: "Messages2",
                newName: "IX_Messages2_MessageReceiverID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages2",
                table: "Messages2",
                column: "MessageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages2_Writers_MessageReceiverID",
                table: "Messages2",
                column: "MessageReceiverID",
                principalTable: "Writers",
                principalColumn: "WriterID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages2_Writers_MessageSenderID",
                table: "Messages2",
                column: "MessageSenderID",
                principalTable: "Writers",
                principalColumn: "WriterID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages2_Writers_MessageReceiverID",
                table: "Messages2");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages2_Writers_MessageSenderID",
                table: "Messages2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages2",
                table: "Messages2");

            migrationBuilder.RenameTable(
                name: "Messages2",
                newName: "Message2");

            migrationBuilder.RenameIndex(
                name: "IX_Messages2_MessageSenderID",
                table: "Message2",
                newName: "IX_Message2_MessageSenderID");

            migrationBuilder.RenameIndex(
                name: "IX_Messages2_MessageReceiverID",
                table: "Message2",
                newName: "IX_Message2_MessageReceiverID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message2",
                table: "Message2",
                column: "MessageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Message2_Writers_MessageReceiverID",
                table: "Message2",
                column: "MessageReceiverID",
                principalTable: "Writers",
                principalColumn: "WriterID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message2_Writers_MessageSenderID",
                table: "Message2",
                column: "MessageSenderID",
                principalTable: "Writers",
                principalColumn: "WriterID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
