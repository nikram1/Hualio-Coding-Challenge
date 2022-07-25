# Hualio-Coding-Challenge

Backend:

1. ASP.Net Core
2. Entity Framwork Code first approach
3. Database name "HualioCodingChallenge"
4. Repository pattern with Unit of work and dependency injection
5. Backend pagination, filteration and sorting.


Frontend:

1. Angular 13
2. Modular application with Lazy loading
3. Working searchbar in header loading to product listing screen
4. Product details screen
5. Home screen


API: 

POST: https://localhost:44384/api/products/createProduct
Body:
{
        productID: 1,
        price: : 10
        name: "product 1"
        productImage: "imageUrl"
        description: "description"
}


POST: https://localhost:44384/api/products/getProducts
Body:
{
        searchValue: "",
        sortColumn: "",
        sortOrder: "",
        pageSize: "",
        pageNo: ""
}


GET: https://localhost:44384/api/products/getProductById/{productId}

PUT: http/api/products/updateProduct/{productId}
Body:
{
        productID: 1,
        price: : 10
        name: "product 1"
        productImage: "imageUrl"
        description: "description"
}


DELETE: https://localhost:44384/api/products/deleteProductById/{productId}