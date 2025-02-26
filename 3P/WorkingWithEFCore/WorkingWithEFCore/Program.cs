//Un indice es para hacer jerarquia de una tabla
//Un indice en bd se hacen ya que hay bases de datos enormes
//Se le debe agregar a un campo
//Reordena la tabla
//crea una tabla en torno a esa tabla
//y esta reordenada en torno al valor que se escribe
//CREATE INDEX "LastName" ON "Employees"("LastName");
//Se puede organizar en torno a un parametro en especial

//Caro
//Gael
//Angel
//busco a angel

//Tendria que pasar por caro y gael
//Pero si los ordeno por alfabetico, es mas rapido

//Crear un indice depende de cuanto pesa la bd, y por ende, precios y espacios

//los index guarda la manera en como se escribio, solo lee puro texto
//los backupps no superan el giga

//ORM: OBJECT RELATIONAL MAPPING

//
//
/*
Mapea las clases, digamos teacher

Con las tablas

Entity framework core 7 EF core 7

linq: es una manera de poder jenerar F# (Efe sharp), dentro de linq

Programacion oriendata a funciones

Una lambda puede tener where(predicado), ForstOfDefault

Una lambda tiene 2 partes en el Pedicado
(a => a.Id == Id)

Son funciones que hacen la query por mi

*/

using WorkingWithEFCore;
Northwind db = new();
WriteLine($"Provider: {db.Database.ProviderName}"); //el proveedor es sqlite, si se usa sqlserver apareceria

//Querys

// QueryCategories();
// FilterIncludes();
// QueryProducts();
// QueryingWithLike();
// GetRandomProduct();

// ListProducts(new int[] {071});


var productMedia = db.Products.Select(product => product.Discontinued).media();
var productMediana = db.Products.Select(product => product.Discontinued).mediana();
var productModa = db.Products.Select(product => product.Discontinued).moda();

// var CategoryMedia = db.Categories.Select(c =>c.Description).media();

// var productMedia = db.Products.Select(product => product.ProductName).media();
// var productMediana = db.Products.Select(product => product.ProductName).mediana();
// var productModa = db.Products.Select(product => product.ProductName).moda();

WriteLine($"Media: {productMedia.ToString("F4")}\nMediana: {productMediana} \nModa: \nCaracter + repetido: "
+$"{productModa.OrderByDescending(c => c.Value).First().Key}\nNumero de veces que se repite: "
+$"{productModa.Max(m =>m.Value)}");

//paginator

WriteLine();

bool flag = true;
sbyte pag = 1;
int actualpag = 1;
WriteLine("Paginado: ");
WriteLine("key 1 = 1");
WriteLine("key 2 = 5");
WriteLine("key 3 = 10");
WriteLine("key 4 = 25");
WriteLine("key 5 = 30");

char paginado;
paginado = Console.ReadKey().KeyChar;
switch (paginado)
{
    case '1':
        {
            pag = 1;
            break;
        }
    case '2':
        {
            pag = 5;
            break;
        }
    case '3':
        {
            pag = 10;
            break;
        }
    case '4':
        {
            pag = 25;
            break;
        }
    case '5':
        {
            pag = 30;
            break;
        }
    default:
        pag = 1;
        break;
}
int startsection = 0, endsection = pag;
ListProductsPaginator(null, startsection, endsection);
for (int i = 0; i <= 75; i++)
{
    Write("-");
}
WriteLine();

Write($"{pag,-17} {actualpag}/{77 / pag, -24}T:77");

ReadLine();
Clear();

while (flag)
{
    if (Console.ReadKey().Key == ConsoleKey.RightArrow)
    {
        if (endsection + pag >= 77)
        {
            startsection = endsection - pag;
            endsection = 77;
            actualpag = 77;
        }
        else
        {
            startsection = endsection;
            endsection = startsection + pag;
            actualpag++;
        }
    }
    else if (Console.ReadKey().Key == ConsoleKey.LeftArrow)
    {
        if (startsection - pag <= 0)
        {
            startsection = 0;
            endsection = pag;
            actualpag = 1;
        }
        else
        {
            endsection = startsection;
            startsection = endsection - pag;
            actualpag--;
        }
    }
    if (pag == 1) { 
        ListProductsPaginator(null, endsection, endsection);
     }else
     {
        ListProductsPaginator(null, startsection, endsection);
     }
    for (int i = 0; i <= 75; i++)
    {
        Write("-");
    }
    WriteLine();
    Write($"{pag,-17} {actualpag}/{77 / pag, -24}T:77");

    ReadLine();
    Clear();
}



/*
        ListProducts();
            // Use of Create
            var resultAdd = AddProduct(categoryId: 6, productName: "La Pizza de Don Cangrejo", price: 500M);
            AddProduct(categoryId: 6, productName: "La Pizza de Don Cangrejo", price: 500M);
            AddProduct(categoryId: 6, productName: "La Pizza de Don Cangrejo", price: 500M);
            AddProduct(categoryId: 6, productName: "La Pizza de Don Cangrejo", price: 500M);
            if(resultAdd.affected == 1)
            {
                WriteLine($"Add product succesful with ID: {resultAdd.ProductId}");
            }
        ListProducts(new int[] {resultAdd.ProductId});

*/

//update
/*
var resultUpdate = UpdateProductPrice(productNameStarWith:"La ", amount: 40M);
if(resultUpdate.affected == 1)
{
    WriteLine($"Increase price success for id: {resultUpdate.prodctId}");
}
ListProducts(productsToHiglight: new[] {resultUpdate.prodctId});
*/

/*

        //use betta update
        var resultUpdateBetter = UpdateProductPriceBetter(productNameStarWith: "La ", amount: 20M);
        if(resultUpdateBetter.affected >0)
        {
            WriteLine("Increase product price succesful.");
        }
        ListProducts(resultUpdateBetter.prodctId);


        //delete

        WriteLine("About to delete all products that start with 'La '");
        Write("Press Enter to conrinue : ");
        if(ReadKey(intercept: true).Key == ConsoleKey.Enter)
        {
            int deleted = DeleteProductsBetter(productnameStartWith: "La ");
            WriteLine($"{deleted} product(s) were deleted");
        }
        else
        {
            WriteLine("Delete was canceled");
        }

        ListProducts();

*/

/*
Cuando se trata de bd, hay distintos tipos de carga == loads

Lo que hace EFC carga toda la bd
Lo hace via tablas
Hay distintos tipos de cargas

La unica query que se usa de momento es GetRandomProduct

El compilador sabe que es lo que se va a utilizar para tener 
para poder correr la query

3 tipos

Eager loading:
    load data early
    -> load all entities at start.
    Load everything

    memory excess copared


Lazy loading
    Load data automatically just before its needed

    Memory Efficient
    If the table its too big enough
    Create a Delay
    But its can make a work arround?
    Crea todas sus querys asincronas


Explicit loading

    Load data manually
    Yo doy de alta todas las tablas al inicio
    O segun el tiempo que las necesito
*/