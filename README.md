# Connection string to database
Server=tcp:testtasks.database.windows.net,1433;Initial Catalog=HostingTestTask;Persist Security Info=False;User ID=Rafael;Password=Leafar2%7;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
# ApiKey
2aa2d17b98df455594422c3a88b428ef
# link
https://testtask-f5g9d3b9gwd6e5az.israelcentral-01.azurewebsites.net/
---

# API Documentation

## Overview
This API provides endpoints to manage contracts, equipment, and facilities in a production environment. All endpoints are secured using an API key provided in the request header.

---

## Authentication
The API uses **API Key authentication**. Include the API key in the `x-api-key` header for all requests.

### Example:
```
x-api-key: your-api-key-here
```

---

## Endpoints

### **Contract Endpoints**

#### **1. Get All Contracts**
- **URL**: `/api/Contract/GetAll`
- **Method**: `GET`
- **Description**: Retrieves a list of all contracts.
- **Security**: Requires API key.
- **Responses**:
  - `200 OK`: List of contracts.

---

#### **2. Add Contract**
- **URL**: `/api/Contract/Add`
- **Method**: `POST`
- **Description**: Adds a new contract.
- **Security**: Requires API key.
- **Request Body**:
  ```json
  {
    "name": "string",
    "facilityId": 1,
    "equipmentId": 1,
    "equipmentCount": 5
  }
  ```
  - `name` (string, nullable): Name of the contract.
  - `facilityId` (integer): ID of the facility.
  - `equipmentId` (integer): ID of the equipment.
  - `equipmentCount` (integer): Quantity of equipment.
- **Responses**:
  - `200 OK`: Contract successfully created.

---

### **Equipment Endpoints**

#### **1. Get All Equipment**
- **URL**: `/api/Equipment/GetAll`
- **Method**: `GET`
- **Description**: Retrieves a list of all equipment.
- **Security**: Requires API key.
- **Responses**:
  - `200 OK`: List of equipment.

---

#### **2. Add Equipment**
- **URL**: `/api/Equipment/Add`
- **Method**: `POST`
- **Description**: Adds new equipment.
- **Security**: Requires API key.
- **Request Body**:
  ```json
  {
    "name": "string",
    "area": "string"
  }
  ```
  - `name` (string, nullable): Name of the equipment.
  - `area` (string, nullable): Area occupied by the equipment.
- **Responses**:
  - `200 OK`: Equipment successfully created.

---

### **Facility Endpoints**

#### **1. Get All Facilities**
- **URL**: `/api/Facility/GetAll`
- **Method**: `GET`
- **Description**: Retrieves a list of all facilities.
- **Security**: Requires API key.
- **Responses**:
  - `200 OK`: List of facilities.

---

#### **2. Add Facility**
- **URL**: `/api/Facility/Add`
- **Method**: `POST`
- **Description**: Adds a new facility.
- **Security**: Requires API key.
- **Request Body**:
  ```json
  {
    "name": "string",
    "area": "string"
  }
  ```
  - `name` (string, nullable): Name of the facility.
  - `area` (string, nullable): Area of the facility.
- **Responses**:
  - `200 OK`: Facility successfully created.

---

## Data Transfer Objects (DTOs)

### **1. CreateContractDTO**
- Used for adding new contracts.
- **Fields**:
  - `name` (string, nullable): Name of the contract.
  - `facilityId` (integer): ID of the related facility.
  - `equipmentId` (integer): ID of the related equipment.
  - `equipmentCount` (integer): Number of equipment in the contract.

---

### **2. CreateEquipmentDTO**
- Used for adding new equipment.
- **Fields**:
  - `name` (string, nullable): Name of the equipment.
  - `area` (string, nullable): Area occupied by the equipment.

---

### **3. CreateProductionFacilityDTO**
- Used for adding new production facilities.
- **Fields**:
  - `name` (string, nullable): Name of the production facility.
  - `area` (string, nullable): Total area of the facility.

---

## Security Schemes

### API Key
- **Type**: `apiKey`
- **Description**: The API key is used to authenticate requests.
- **Header Name**: `x-api-key`

---

## Example Request Using API Key
### **Request**:
```http
POST /api/Contract/Add HTTP/1.1
Host: example.com
x-api-key: your-api-key-here
Content-Type: application/json

{
  "name": "New Contract",
  "facilityId": 1,
  "equipmentId": 2,
  "equipmentCount": 10
}
```

### **Response**:
```http
HTTP/1.1 200 OK
{
  "message": "Contract successfully created"
}
```

---
