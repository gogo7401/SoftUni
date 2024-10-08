function solve(input) {
    const count = Number(input.shift());
    let sprintBoard = {};

    for (let i = 0; i < count; i++) {
        const [assignee, taskId, title, status, estimatedPoints] = input[i].split(':');
        if (!sprintBoard.hasOwnProperty(assignee)) {
            sprintBoard[assignee] = [];
        }
        sprintBoard[assignee].push({ taskId, title, status, estimatedPoints });
    }

    
    let assignee, taskId, title, status, estimatedPoints, newStatus, index;
    while (input.length != 0) {
        let line = input.shift();
        let [command, ...arg] = line.split(':');
        switch (command) {
            case 'Add New':
                assignee = arg[0];
                taskId = arg[1];
                title = arg[2];
                status = arg[3];
                estimatedPoints = arg[4];
                if (sprintBoard.hasOwnProperty(assignee)) {
                    sprintBoard[assignee].push({ taskId, title, status, estimatedPoints });
                } else {
                    console.log(`Assignee ${assignee} does not exist on the board!`);
                }
                break;

            case 'Change Status':
                assignee = arg[0];
                taskId = arg[1];
                newStatus = arg[2];

                if (!sprintBoard.hasOwnProperty(assignee)) {
                    console.log(`Assignee ${assignee} does not exist on the board!`);
                    break;
                }
                let isTask = findTaskId(sprintBoard[assignee], taskId, newStatus);
                if (!isTask) {
                    console.log(`Task with ID ${taskId} does not exist for ${assignee}!`);
                    break;
                }
                break;

            case 'Remove Task':
                assignee = arg[0];
                index = Number(arg[1]);

                if (!sprintBoard.hasOwnProperty(assignee)) {
                    console.log(`Assignee ${assignee} does not exist on the board!`);
                    break;
                }

                if (index < 0 || index >= sprintBoard[assignee].length) {
                    console.log('Index is out of range!');
                    break;
                }

                sprintBoard[assignee].splice(index, 1);

                break;
        }
    }

    function findTaskId(array, taskId, newStatus) {
        let result = false;
        // let [...arrays] = array;
        // // console.log(arrays);
        // arrays.forEach(e => {
        //     if (e.taskId === taskId) {
        //         e.status = newStatus;
        //         result = true;
        //     }
        // });

        const task = array.find((t) => t.taskId === taskId);
        if (task) { 
            task.status = newStatus;
            result = true;
        }

        return result;
    }


    // print output

    function takePoints(status) {
        let points = 0;

        Object.entries(sprintBoard).forEach(element => {
            element[1].forEach(e => {
                if (e.status === status) { points += Number(e.estimatedPoints); }
            });
        });
        return points;
    }

    let toDo = takePoints('ToDo');
    let inProgress = takePoints('In Progress');
    let codeReview = takePoints('Code Review');
    let done = takePoints('Done');

    console.log(`ToDo: ${toDo}pts`);
    console.log(`In Progress: ${inProgress}pts`);
    console.log(`Code Review: ${codeReview}pts`);
    console.log(`Done Points: ${done}pts`);
    if (done >= (toDo + inProgress + codeReview)) {
        console.log('Sprint was successful!');
    } else {
        console.log('Sprint was unsuccessful...');
    }

    // console.log(sprintBoard);
}


// solve([
//     '5',
//     'Kiril:BOP-1209:Fix Minor Bug:ToDo:3',
//     'Mariya:BOP-1210:Fix Major Bug:In Progress:3',
//     'Peter:BOP-1211:POC:Code Review:5',
//     'Georgi:BOP-1212:Investigation Task:Done:2',
//     'Mariya:BOP-1213:New Account Page:In Progress:13',
//     'Add New:Kiril:BOP-1217:Add Info Page:In Progress:5',
//     'Change Status:Peter:BOP-1290:ToDo',
//     'Remove Task:Mariya:1',
//     'Remove Task:Joro:1',
// ]);


solve([
    '4',
    'Kiril:BOP-1213:Fix Typo:Done:1',
    'Peter:BOP-1214:New Products Page:In Progress:2',
    'Mariya:BOP-1215:Setup Routing:ToDo:8',
    'Georgi:BOP-1216:Add Business Card:Code Review:3',
    'Add New:Sam:BOP-1237:Testing Home Page:Done:3',
    'Change Status:Georgi:BOP-1216:Done',
    'Change Status:Will:BOP-1212:In Progress',
    'Remove Task:Georgi:3',
    'Change Status:Mariya:BOP-1215:Done',
]);
