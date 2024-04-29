<h1>Endpoints</h1>
<h2>User</h2>

|            Endpoint             | Method |     Request      | Response | Response codes |
|:-------------------------------:|:------:|:----------------:|:--------:|:--------------:|
|              /user              |  GET   |       NONE       |  User[]  |      200       |
|        /user/region/{id}        |  GET   |       int        |  User[]  |    200, 400    |
|         /user/city/{id}         |  GET   |       int        |  User[]  |    200, 400    |
|          /user/id/{id}          |  GET   |       int        |   User   | 200, 400, 404  |
|       /user/email/{email}       |  GET   |      string      |   User   | 200, 400, 404  |
|         /user/authorize         |  GET   |       NONE       |   int    |    200, 401    |
| /user/EmailIsRegistered/{email] |  GET   |      string      |   bool   |      200       |
|              /user              |  POST  |       User       |   NONE   |    200, 400    |
|           /user/login           |  POST  | AuthenticateUser |  string  |    200, 400    |
|              /user              | PATCH  |       User       |   NONE   | 200, 400, 404  |
|          /user/id/{id}          | DELETE |       int        |   User   | 200, 400, 404  |

<h2>Product</h2>

|         Endpoint         | Method |   Request    | Response  | Response codes |
|:------------------------:|:------:|:------------:|:---------:|:--------------:|
|         /product         |  GET   |     NONE     | Product[] |      200       |
| /product/search/{query}  |  GET   |    string    | Product[] |    200, 400    |
|     /product/id/{id}     |  GET   |     int      |  Product  | 200. 400, 404  |
|  /product/category/{Id}  |  GET   |     int      | Product[] | 200, 400, 404  |
|         /product         |  POST  |   Product    |   NONE    |    200, 400    |
|         /product         | PATCH  |   Product    |   NONE    | 200, 400, 404  |
|   /product/addToStock    | PATCH  | ProductStock |   NONE    |  200, 400,404  |
| /product/removeFromStock | PATCH  | ProductStock |   NONE    |  200, 400,404  |
|     /product/id/{id}     | DELETE |     int      |   NONE    | 200, 400, 404  |

<h2>Category</h2>

|    Endpoint    | Method | Request |  Response  | Response codes |
|:--------------:|:------:|:-------:|:----------:|:--------------:|
|   /category    |  GET   |  NONE   | Category[] |      200       |
| /category/{id} |  GET   |   int   |  Category  | 200, 400, 404  |
|   /category    |  POST  | string  |    NONE    |    200, 400    |
| /category/{id} | DELETE |   int   |    NONE    |    200, 400    |

<h2>Order</h2>

|    Endpoints     | Method | Request | Response | Response codes |
|:----------------:|:------:|:-------:|:--------:|:--------------:|
|  /order/id/{id}  |  GET   |   Int   |  Order   | 200, 400, 404  |
| /order/user/{id} |  GET   |   Int   | Order[]  | 200, 400, 404  |
|      /order      |  POST  |  Order  |   NONE   |    200, 400    |

<h2>City</h2>

| Endpoint | Method | Request | Response | Response codes |
|:--------:|:------:|:-------:|:--------:|:--------------:|
|  /city   |  GET   |  NONE   |  City[]  |      200       |
|  /city   |  POST  |  City   |   NONE   |    200, 400    |

<h2>Region</h2>

| Endpoint | Method | Request | Response | Response codes |
|:--------:|:------:|:-------:|:--------:|:--------------:|
| /region  |  GET   |  NONE   | Region[] |      200       |
| /region  |  POST  | string  |   NONE   |    200, 400    |

<h1>Responses</h1>

<h3>User</h3>
<ul>
    <li>id : int</li>
    <li>firstName : string</li>
    <li>lastName : string</li>
    <li>email : string</li>
    <li>phone : string</li>
    <li>address : string</li>
</ul>

<h3>Product</h3>
<ul>
    <li> id : int</li>
    <li> name : string</li>
    <li> description : string</li>
    <li> price : Float</li>
    <li> category : string</li>
    <li> stock : Int</li>
    <li>isDiscontinued: bool</li>
</ul>

<h3>Order</h3>
<ul>
    <li>id : int</li>
    <li>date : dateTime</li>
    <li>products : OrderProduct[]</li>
</ul>

<h3>OrderProduct</h3>
<ul>
    <li>id : int</li>
    <li>name : string</li>
    <li>price : decimal</li>
    <li>amount : int</li>
</ul>

<h3>City</h3>
<ul>
    <li>id : int</li>
    <li>name : string</li>
    <li>region : Region</li>
</ul>

<h3>Region</h3>
<ul>
    <li>id : int</li>
    <li>name : string</li>
</ul>

<h1>Requests</h1>

<h3>User</h3>
<ul>
    <li>firstName : string</li>
    <li>lastName : string</li>
    <li>email : string</li>
    <li>phone : string</li>
    <li>password : string</li>
    <li>address : Address</li>
    <li>id : int (optional, use at Update)</li>
</ul>

<h3>AuthenticateUser</h3>
<ul>
    <li>email : string</li>
    <li>password : string</li>
</ul>

<h3>Address</h3>
<ul>
    <li>cityId : int</li>
    <li>street : string</li>
    <li>postalCode : string</li>
</ul>

<h3>Product</h3>
<ul>
    <li>name : string</li>
    <li>description : string</li>
    <li>price : decimal</li>
    <li>categoryId : int</li>
    <li>isDiscontinued : bool (optional, default = false)</li>
    <li>stock : int (optional, default = 0)</li>
    <li>Id : int (optional, use at Update)</li>
</ul>

<h3>ProductStock</h3>
<ul>
    <li>productId : int</li>
    <li>amount : int</li>
</ul>
<h3>City</h3>
<ul>
    <li>name : string</li>
    <li>regionId : int</li>
</ul>


<h3>Order</h3>
<ul>
    <li>userId : int</li>
    <li>products : OrderProduct[]</li>
</ul>

<h3>OrderProduct</h3>
<ul>
    <li>productId : int</li>
    <li>amount : int</li>
</ul>