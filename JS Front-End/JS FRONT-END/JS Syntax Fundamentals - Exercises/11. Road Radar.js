function PrintRoadRadar(speed, area) {
    if (area == 'motorway') {
        const speedLimit = 130;
        let status = '';
        let difference = speed - speedLimit;
        if (speed <= speedLimit) {
            console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
        } else {
            if (difference <= 20) {
                status = 'speeding';
            } else {
                if (difference <= 40){
                    status = 'excessive speeding';
                } else {
                    status = 'reckless driving';
                }
            }
            console.log(`The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
        }
    }

    if (area == 'interstate') {
        const speedLimit = 90;
        let status = '';
        let difference = speed - speedLimit;
        if (speed <= speedLimit) {
            console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
        } else {
            if (difference <= 20) {
                status = 'speeding';
            } else {
                if (difference <= 40){
                    status = 'excessive speeding';
                } else {
                    status = 'reckless driving';
                }
            }
            console.log(`The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
        }
    }

    if (area == 'city') {
        const speedLimit = 50;
        let status = '';
        let difference = speed - speedLimit;
        if (speed <= speedLimit) {
            console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
        } else {
            if (difference <= 20) {
                status = 'speeding';
            } else {
                if (difference <= 40){
                    status = 'excessive speeding';
                } else {
                    status = 'reckless driving';
                }
            }
            console.log(`The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
        }
    }

    if (area == 'residential') {
        const speedLimit = 20;
        let status = '';
        let difference = speed - speedLimit;
        if (speed <= speedLimit) {
            console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
        } else {
            if (difference <= 20) {
                status = 'speeding';
            } else {
                if (difference <= 40){
                    status = 'excessive speeding';
                } else {
                    status = 'reckless driving';
                }
            }
            console.log(`The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
        }
    }
}



PrintRoadRadar(40, 'city');
PrintRoadRadar(21, 'residential');
PrintRoadRadar(120, 'interstate');
PrintRoadRadar(200, 'motorway');
