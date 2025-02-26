CREATE TABLE NewTable (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    -- Otras columnas
);
CREATE TABLE "Categoriesok" (
	"CategoryId" INTEGER PRIMARY KEY AUTOINCREMENT,
	"CategoryName" nvarchar (15) NOT NULL ,
	"Description" "ntext" NULL ,
	"Picture" "image" NULL
);
-- Categories definition
--DROP TABLE "Categoriesok";
CREATE TABLE "Categoriesok" (
	"CategoryId" INTEGER PRIMARY KEY AUTOINCREMENT,
	"CategoryName" nvarchar (15) NOT NULL ,
	"Description" "ntext" NULL ,
	"Picture" "image" NULL
);

CREATE INDEX "CategoryName" ON "Categoriesok"("CategoryName");

INSERT INTO Categoriesok
(CategoryName, Description, Picture)
SELECT CategoryName, Description, Picture From Categories order by CategoryId 
SELECT * FROM Categoriesok 