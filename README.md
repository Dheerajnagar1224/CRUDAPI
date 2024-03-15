# CRUD API
- ## Post

Creating an entity

Api Endpoint: https://localhost:7180/api/Db/CreateEntity

#### Request Body:-
```
{
  "id": "string",
  "deceased": true,
  "gender": "string",
  "address": [
    {
      "addressLine": "string",
      "city": "string",
      "country": "string"
    }
  ],
  "dates": [
    {
      "dateType": "string",
      "dateValue": "2024-03-15T18:24:04.897Z"
    }
  ],
  "names": [
    {
      "firstName": "string",
      "middleName": "string",
      "surname": "string"
    }
  ]
}
```

#### On Failure:

If the Id doesn't exist, it logs a message indicating the absence of the entity and returns a "not found" response.

##### Response:-
```
{
  "code": "2",
  "message": "No  record Available",
  "responseData": null
}
```
For any other exceptions that occurred during the create operation, it logs an error message and returns an internal server error response.

##### Response:-
```
{
  "code": "1",
  "message": null,
  "responseData": "Something went wrong"
}
```

- ## GET
1. Retrieving all entities.<br />
2. Sorting feature on gender, deceased and id to be entered in sortBy parameter and direction can be mentioned in sortDirection parameter. (default: sortBy=Id, sortDirection=asc)<br />
3. Filtering based on addressCountry, gender, startDate and endDate.<br />
4. Searching based on addressCountry, firstName, middleName and surName to be entered in searchQuery parameter.

Api endpoint: https://localhost:7180/api/Db/GetEntities <br />
(Endpoint for features look like)<br />
Pagination & Sorting: https://localhost:7180/api/Db/GetEntities?page=1&pageSize=10&sortBy=Id&sortDirection=asc<br />
Search: https://localhost:7180/api/Db/GetEntities?searchQuery=sdc<br />
Filter: https://localhost:7180/api/Db/GetEntities?addressCountry=india

#### Request Query Parameter
```
string addressCountry
string gender
Datetime startdate
Datetime enddate
string searchQuery
integer page
integer pageSize
string sortBy
string sortDirection
```
#### Response
```
{
  "code": "0",
  "message": "Success",
  "responseData": [
    {
      "id": "4",
      "deceased": true,
      "gender": "male",
      "address": [
        {
          "addressLine": "mumbai",
          "city": "mumbai",
          "country": "india"
        }
      ],
      "dates": [
        {
          "dateType": "string",
          "dateValue": "2024-03-15T14:54:00.455Z"
        }
      ],
      "names": [
        {
          "firstName": "Dheeraj",
          "middleName": "J",
          "surname": "Nagar"
        }
      ]
    }
  ]
}
```
#### On Failure:

For any exceptions that occurred during the GET operation, it logs an error message and returns an internal server error response.

##### Response
```
{
  "code": "1",
  "message": null,
  "responseData": "Something went wrong"
}
```



- ## Getbyid
Retrieving a particular entity based on ID.

Api endpoint: https://localhost:7180/api/Db/Getbyid/{id}

#### Request query parameter
```
string id
```
#### Response:-
```
{
  "code": "0",
  "message": "Success",
  "responseData": {
    "id": "4",
    "deceased": true,
    "gender": "male",
    "address": [
      {
        "addressLine": "mumbai",
        "city": "mumbai",
        "country": "india"
      }
    ],
    "dates": [
      {
        "dateType": "string",
        "dateValue": "2024-03-15T14:54:00.455Z"
      }
    ],
    "names": [
      {
        "firstName": "Dheeraj",
        "middleName": "J",
        "surname": "Nagar"
      }
    ]
  }
}
```

#### On Failure:

If the Id doesn't exist, it logs a message indicating the absence of the entity and returns a "not found" response.

##### Response:-
```
{
  "code": "2",
  "message": "No  record Available",
  "responseData": null
}
```
For any other exceptions that occurred during the get by id operation, it logs an error message and returns an internal server error response.

##### Response:-
```
{
  "code": "1",
  "message": null,
  "responseData": "Something went wrong"
}
```

- ## UPDATE
Updates the entity based on Id.

Api endpoint: https://localhost:7180/api/Db/UpdateEntity/{id}

#### Request Query Parameter
```
string id
```
#### Request Body
```
{
  "id": "4",
  "deceased": true,
  "gender": "male",
  "address": [
    {
      "addressLine": "mumbai",
      "city": "mumbai",
      "country": "india"
    }
  ],
  "dates": [
    {
      "dateType": "string",
      "dateValue": "2024-03-15T14:54:00.455Z"
    }
  ],
  "names": [
    {
      "firstName": "Dheeraj",
      "middleName": "J",
      "surname": "Nagar"
    }
  ]
}

```
#### Response:-
```
{
  "code": "0",
  "message": "Success",
  "responseData": null
}
```
#### On Failure:

If the Id doesn't exist, it logs a message indicating the absence of the entity and returns a "not found" response.

##### Response:-
```
{
  "code": "2",
  "message": "No  record Available",
  "responseData": null
}
```
For any other exceptions that occurred during the update operation, it logs an error message and returns an internal server error response.

##### Response:-
```
{
  "code": "1",
  "message": null,
  "responseData": "Something went wrong"
}
```



- ## DELETE
Deleting a particular entity based on ID.

Api endpoint: https://localhost:7180/api/Db/DeleteEntity/{id}

#### Request:-
```
string id
```
#### Response:-
```
{
  "code": "0",
  "message": "Success",
  "responseData": null
}
```
#### On Failure:

If the Id doesn't exist, it logs a message indicating the absence of the entity and returns a "not found" response.

##### Response:-
```
{
  "code": "2",
  "message": "No  record Available",
  "responseData": null
}
```
For any other exceptions that occurred during the delete operation, it logs an error message and returns an internal server error response.

##### Response:-
```
{
  "code": "1",
  "message": null,
  "responseData": "Something went wrong"
}
```




