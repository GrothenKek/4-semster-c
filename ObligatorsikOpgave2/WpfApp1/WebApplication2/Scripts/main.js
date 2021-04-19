let startDatePicker = document.querySelector('#StartDate');
let endDatePicker = document.querySelector('#EndDate');
let selectTool = document.querySelector('#ToolId');

let startDate,
    endDate,
    toolId;

function init() {
  
    startDatePicker.addEventListener(('change'), (e) => {
        startDate = e.target.value;
        console.log(startDate);
    });


    endDatePicker.addEventListener(('change'), (e) => {
        endDate = e.target.value;
        console.log(endDate);
       
    });

    selectTool.addEventListener(('change'), (e) => {
        toolId = e.target.value;
        console.log(toolId);

        let priceModel = {
            ToolID: toolId,
            StartDate: startDate,
            EndDate: endDate
        };

        calculatePrice(priceModel);
    });


}

init();

function calculatePrice(priceModel) {
    console.log(priceModel);
    fetch('/Reservations/CalculatePrice', {
        method: 'post',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(priceModel)
    })
        .then(res => res.json())
        .then(data => {
            let priceField = document.getElementById('Price');
            priceField.value = data;
        });
} 