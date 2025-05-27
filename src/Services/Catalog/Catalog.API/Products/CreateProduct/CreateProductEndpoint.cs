namespace Catalog.API.Products.CreateProduct;


public record CreateProductRequest( Guid Id , string Name ,List<string> Category ,
                                    string Description ,string ImageFile ,decimal Price );


public record CreateProductResponse(Guid Id);

public class CreateProductEndpoint
{
    
}