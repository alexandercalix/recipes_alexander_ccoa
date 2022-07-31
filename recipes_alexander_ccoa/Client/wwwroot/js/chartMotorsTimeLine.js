
let chart;

function ChartMotorTimeLine(data1) {
    console.log("Hola 1")
    document.getElementById("chart-container").innerHTML = ``
    console.log("Hola 2")

    document.getElementById("chart-container").innerHTML = `<canvas id="chartTimeLineMotor" width="400" height="400"></canvas>`
    console.log("Hola 3")

    console.log(data1);
    //chartTimeLineMotor
    //data = [
    //    { id: 2, name: "Season Apples", start_date: "2022-03-07 15:00:00.000", end_date: "2022-03-10 15:00:00.000" },
    //    { id: 1, name: "Cut Apples", start_date: "2022-03-05 15:00:00.000", end_date: "2022-03-07 15:00:00.000" },
    //    { id: 3, name: "Bake Apples", start_date: "2022-03-11 15:00:00.000", end_date: "2022-03-15 15:00:00.000" }
    //]

    const data = data.map(x => {
        id: x.id,
        name: x.status,
        start_data: x.start,
        end_date: x.end
    })


    // sort objects by start_date
    data.sort(function (a, b) {
        return new Date(a.start_date) - new Date(b.start_date);
    });
    // chart js needs labels in separate array
    const labels = data.map(x => {
        return [x.name];
    })
    // transform the data from how the backend outputs it to how the chart js needs it
    const newData = data.map(x => {
        return [x.start_date.split(' ')[0], x.end_date.split(' ')[0]]
    });

    data = {
        labels: labels,
        datasets: [{
            label: 'Make Apple Recipe',
            data: newData,
            backgroundColor: 'rgba(255, 99, 132, 0.2)',
            borderColor: 'rgba(255, 99, 132, 1)',
            borderWidth: 1,
            fill: false,
            barPercentage: 0.3
        }]
    };

    options = {
        indexAxis: 'x',
        responsive: true,
        scales: {
            x: {
                min: newData[0][0],
                type: 'timeseries',
                time: {
                    unit: 'day'
                }
            },
            y: {
                beginAtZero: true,
            }
        }
    };

   
   // if (chart) chart.destroy();

    chart = new Chart(document.getElementById('chartTimeLineMotor').getContext('2d'), {
        type: 'line', data: data, options: options
    });

}