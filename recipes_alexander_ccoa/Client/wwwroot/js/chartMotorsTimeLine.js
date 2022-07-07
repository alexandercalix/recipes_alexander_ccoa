
function chartMotorTimeLine(data1)
{
    console.log(data1);
    //chartTimeLineMotor
    data = [
        { id: 2, name: "Season Apples", start_date: "2022-03-07 15:00:00.000", end_date: "2022-03-10 15:00:00.000" },
        { id: 1, name: "Cut Apples", start_date: "2022-03-05 15:00:00.000", end_date: "2022-03-07 15:00:00.000" },
        { id: 3, name: "Bake Apples", start_date: "2022-03-11 15:00:00.000", end_date: "2022-03-15 15:00:00.000" }
    ]
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
        indexAxis: 'y',
        responsive: true,
        scales: {
            x: {
                min: newData[0][0],
                type: 'time',
                time: {
                    unit: 'day'
                }
            },
            y: {
                beginAtZero: true,
            }
        }
    };

    new Chart(document.getElementById('chartTimeLineMotor').getContext('2d'), {
        type: 'bar', data: data, options: options
    });

}