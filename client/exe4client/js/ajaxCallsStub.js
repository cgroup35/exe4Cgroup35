Flats = [
     {
         Id : 1,
         City: "3",
         Address: "Mazda",
         NumberOfRooms: 2,
         Price: 150,
         Image: "Car1.jpg",

     },
    {
        Id: 2,
        City: "3",
        Address: "Mazda",
        NumberOfRooms: 2,
        Price: 150,
        Image: "Car1.jpg",
         //Id: 1001,
         //Model: "3",
         //Manufacturer: "Mazda",
         //Price: 90000,
         //Year: 2016,
         //Hand: 2,
         //Color: "White",
         //Automatic: true,
         //Image: "Car3.jpg",
         //Description: "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book."
     },
     {
         Id: 3,
         City: "3",
         Address: "Mazda",
         NumberOfRooms: 2,
         Price: 150,
         Image: "Car1.jpg",
     },
     {
         
         Id: 4,
         City: "3",
         Address: "Mazda",
         NumberOfRooms: 2,
         Price: 150,
         Image: "Car1.jpg",
     },
     {
         Id: 5,
         City: "3",
         Address: "Mazda",
         NumberOfRooms: 2,
         Price: 150,
         Image: "Car1.jpg",
       
     },
     {
         Id: 6,
         City: "3",
         Address: "Mazda",
         NumberOfRooms: 2,
         Price: 150,
         Image: "Car1.jpg",
     }
];


function ajaxCall(method, api, data, successCB, errorCB) {
    //$.ajax({
    //    type: method,
    //    url: api,
    //    data: data,
    //    cache: false,
    //    contentType: "application/json",
    //    dataType: "json",
    //    success: successCB,
    //    error: errorCB
    //});

    if (method == "GET" && api == "../api/flats") {
        successCB(Flats);
        return;
    }

    else if (method == "PUT" && api == "../api/cars") {
        let car = JSON.parse(data);
        for (var i = 0; i < Cars.length; i++) {
            if (Cars[i].Id == car.Id) {
                Cars[i] = car;
                
                successCB(Cars);
                return;
            }
        }

        errorCB("did not manage to update the DB");
    }


    else if (method == "POST" && api == "../api/cars") {
        let car = JSON.parse(data);
        car.Id = getMaxId(Cars) + 1;
        Cars.push(car);
        successCB(Cars);
        //errorCB("did not manage to insert the new car into the DB");
    }

    else if (method == "DELETE") {
        splitArr = api.split('/');
        let id = splitArr[splitArr.length - 1];
        temp = [];
        index = 0;
        for (var i = 0; i < Cars.length; i++) {
            if (parseInt(Cars[i].Id) != id) {
                temp[index] = Cars[i];
                index++;
            }
        }
        Cars = temp;
        successCB(Cars);
    }


}

function getMaxId(cars){
    let max = 0;
    for (var i = 0; i < cars.length; i++) {
        if (cars[i].Id > max)
            max = cars[i].Id;
    }
    return max;
}