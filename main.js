//initiate the collection
let tasks = [];

//get DOM elements
const taskForm = document.getElementById("task-form");
const taskName = document.getElementById("tname");
const taskDesc = document.getElementById("tdescription");
const taskStatus = document.getElementById("tstatus");
const taskDeadline = document.getElementById("tdeadline");
const taskList = document.querySelector(".task-list");

//addEventListener & preventDefault
taskForm.addEventListener("submit", function(event){
    event.preventDefault();

    const task = {
    id: Date.now(),
    title: taskName.value,
    description: taskDesc.value,
    status: taskStatus.value,
    deadline: taskDeadline.value
  };

  tasks.push(task);
  console.log(tasks);
  renderTasks();

  taskForm.reset();  
});

//#region Functions

// function getLocalDateTimeString() {
//     const now = new Date();
//     const offset = now.getTimezoneOffset();
//     const local = new Date(now.getTime() - offset * 60000);
//     return local.toISOString().slice(0, 16);
// }

function renderTasks() {
  
  taskList.innerHTML = "";

  const statusMap = {
  "Pending": "todo",
  "In progress": "doing",
  "Completed": "done"
  };

  if (tasks.length === 0) {
  taskList.innerHTML = "<p>No tasks yet</p>";
  return;
}

  tasks.forEach(function(task){


    const taskItem = document.createElement("li");
    taskItem.classList.add("task-item");

    taskItem.innerHTML = `
      <h4>${task.title}</h4>
      <p>${task.description}</p>
      <span class="badge ${statusMap[task.status]}">
        ${task.status}
      </span>
      <p>Deadline: ${task.deadline}</p>
      <button class="btn-edit">Edit</button>
      <button class="btn-delete">Delete</button>
    `;

    taskList.appendChild(taskItem);
  });
}
renderTasks();
//#endregion