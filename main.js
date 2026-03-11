//#region States
let tasks = [];
let editingId = null;
//#endregion

//#region Inits
//get DOM elements
const taskForm = document.getElementById("task-form");
const taskName = document.getElementById("tname");
const taskDesc = document.getElementById("tdescription");
const taskStatus = document.getElementById("tstatus");
const taskDeadline = document.getElementById("tdeadline");
const taskList = document.querySelector(".task-list");
const submitBtn = taskForm.querySelector("button");
const taskFormTitle = document.getElementById("tform-title");

load();
renderTasks();
//#endregion

//#region Events
taskForm.addEventListener("submit", handleSubmit);

function handleSubmit(event){
  event.preventDefault();
  addOrEditTask();
}

taskList.addEventListener("click", function(e) {

  if (e.target.classList.contains("btn-delete")) {

    // const id = Number(e.target.dataset.id);
    const id = Number(e.target.closest(".task-item").dataset.id);

    deleteTask(id);
  } else if (e.target.classList.contains("btn-edit")) {
    const id = Number(e.target.closest(".task-item").dataset.id);

    startEditing(id);
  }
});

function isEditing(){
  return editingId !== null
}
//#endregion

//#region Actions
//ADD & EDIT TASK
function addOrEditTask(){
  if (!isEditing()) {
    //ADD task
    const task = {
      id: Date.now(),
      title: taskName.value,
      description: taskDesc.value,
      status: taskStatus.value,
      deadline: taskDeadline.value
    };

    tasks.push(task);
  } else {
    //EDIT task
    tasks = tasks.map(task =>
      task.id === editingId
        ? {
            ...task,
            title: taskName.value,
            description: taskDesc.value,
            status: taskStatus.value,
            deadline: taskDeadline.value
          }
        : task
    );

    editingId = null;
    renderForm();
  }

  save(tasks);
  renderTasks();
  taskForm.reset();  
}

function deleteTask(id) {
  tasks = tasks.filter(task => task.id !== id);
      
  if (editingId === id) {
  editingId = null;
  taskForm.reset();
  renderForm();
  }

  save(tasks);
  renderTasks();
}

function startEditing(id) {
  const task = tasks.find(t => t.id === id);

    taskName.value = task.title;
    taskDesc.value = task.description;
    taskStatus.value = task.status;
    taskDeadline.value = task.deadline;
    //change editingId to change state from ADD to EDIT
    editingId = id;
    renderForm();
}
//#endregion

//#region Persistence
// function getLocalDateTimeString() {
//     const now = new Date();
//     const offset = now.getTimezoneOffset();
//     const local = new Date(now.getTime() - offset * 60000);
//     return local.toISOString().slice(0, 16);
// }


function save(list) {
  localStorage.setItem("tasks", JSON.stringify(list));
}

function load() {
  //avoid crashing when parsing from null item
  tasks = JSON.parse(localStorage.getItem("tasks")) || [];
}
//#endregion

//#region Render
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
    taskItem.dataset.id = task.id;

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

function renderForm() {
  if (!isEditing()) {
    submitBtn.textContent = "Add task";
    taskFormTitle.textContent = "Add new task";
  } else {
    submitBtn.textContent = "Update task";
    taskFormTitle.textContent = "Edit task";
  }
}
//#endregion