import React from "react";
import { Card, Button, Form } from "react-bootstrap";
import "./style.css";
import axios from "axios";
import ModalComponent from "../modalComponent/index";

export default class TasksComponent extends React.Component {
  constructor() {
    super();
    this.state = {
      tasks: [],
      newTaskName: "",
      newTaskDescription: "",
      updateTaskName: "",
      updateTaskDescription: "",
      updateTaskId: 0,
      validated: false,
      isFormValidated: false,
      modalShow: false,
      taskToModal: {},
    };
  }

  //Po zamontowaniu komponentu
  componentDidMount() {
    this.getTasks();
  }

  //Ściąga wszystkie taski z backendu
  getTasks() {
    axios.get("/todo").then(res => {
      this.setState({
        tasks: res.data
      });
    });
  }

  updateTask = () => {
    axios
      .put("/todo", {
        id: this.state.updateTaskId,
        name: this.state.updateTaskName,
        description: this.state.updateTaskDescription
      }) //jeśli zakończyłeś dodawanie taska, pobierz wszysktkie i odśwież wlistę tasków
      .then(() => {
        this.getTasks();
      });
  };


  deleteTask = id => {
    axios
    .delete(`/todo/${id}`)
    .then(() => {
        this.getTasks();
    });
  }
  //Dodaje nowy task - w metodzie post jako pierwszy parametr "/todo", ponieważ
  // w package.json mamy proxy "http://localhost:2573/api", a więc to jest pozostała część.
  //Następnym parameterm jest obiekt z właściwościami "name" i "description" - takie same nazwy jakie przyjmuje backend
  addNewTask = e => {
    axios
      .post("/todo", {
        name: this.state.newTaskName,
        description: this.state.newTaskDescription
      }) //jeśli zakończyłeś dodawanie taska, pobierz wszysktkie i odśwież wlistę tasków
      .then(() => {
        this.getTasks();
      });
  };


  //Metoda się wykona z każdą zmianą w inpucie.  [e.target.name] odpowiada nazwie podanej pod "name" w Form.Control, np. name="newTaskName"
  onChange = e => {
    console.log(e.target.value);
    
    this.setState({ [e.target.name]: e.target.value });
  };

  //Renderuje, generuje każdą kartę po kolei. Jeśli opis jest dłuższy niż 100 słów, skraca go i dodaje trzy kropki - "..."
  renderCard = (task, k) => {
    if (task.description.length > 100) {
      var taskShortDescription = task.description.substring(0, 100);
    }
    return (
      <Card
        key={k} //szerokośc 18rem, wysokość jest automatyczna, margines 1rem, kursor po najechani ma być taki jak przy klikaniu
        style={{ width: "18rem", margin: "1rem"}}
      >
        <Card.Header className='card-header'>
          <Card.Title className='card-title'>#{task.id} {task.name}</Card.Title>
          <Button variant="danger" onClick={() => {this.deleteTask(task.id)}}>X</Button>
        </Card.Header>
        <Card.Body className='card-body' onClick={() => {
          this.setState({ modalShow: true, taskToModal: task });
        }}>
          <Card.Text>
            {taskShortDescription
              ? taskShortDescription + "..."
              : task.description}
              
          </Card.Text>
        </Card.Body>
      </Card>
    );
  };

  render() {
    let modalClose = () => this.setState({ modalShow: false });

    const tasks = this.state.tasks
      .slice(0) //odwracanie tablicy, żeby było od najnowszego taska do najstarszego
      .reverse()
      .map((val, index) => {
        return this.renderCard(val, index);
      });

    return (
      <div id="tasksPage">
        <div id="tasks">{tasks}</div>
        <div id="newTask">
          <h1>Add new task:</h1>
          <Form
            id="newTaskForm"
            onSubmit={e => {
              e.preventDefault();
            }}
          >
            <Form.Group>
              <Form.Label>Name:</Form.Label>
              <Form.Control
                type="text"
                placeholder="Enter name"
                name="newTaskName"
                onChange={this.onChange}
                required
              />
            </Form.Group>

            <Form.Group>
              <Form.Label>Description:</Form.Label>
              <Form.Control
                as="textarea"
                rows="5"
                name="newTaskDescription"
                onChange={this.onChange}
              />
            </Form.Group>
            <Button
              variant="primary"
              disabled={this.state.newTaskName === ""}
              onClick={this.addNewTask}
            >
              Submit
            </Button>
          </Form>
          <ModalComponent
            task={this.state.taskToModal}
            show={this.state.modalShow}
            onHide={modalClose}
          />
        </div>

        <div id="updateTask">
          <h1>Update Task:</h1>
          <Form
            id="updateTaskForm"
            onSubmit={e => {
              e.preventDefault();
            }}
          >
           <Form.Group>
              <Form.Label>Id:</Form.Label>
              <Form.Control
                type="text"
                placeholder="Enter id"
                name="updateTaskId"
                onChange={this.onChange}
                required
              />
            </Form.Group>

            <Form.Group>
              <Form.Label>Name:</Form.Label>
              <Form.Control
                type="text"
                placeholder="Enter name"
                onChange={this.onChange}
                name="updateTaskName"
              />
            </Form.Group>

            <Form.Group>
              <Form.Label>Description:</Form.Label>
              <Form.Control
                as="textarea"
                rows="5"
                name="updateTaskDescription"
                onChange={this.onChange}
              />
            </Form.Group>
            <Button
              variant="primary"
              disabled={!this.state.updateTaskId }
              onClick={this.updateTask}
            >
              Update
            </Button>
          </Form>
        </div>
      </div>
    );
  }
}
