import React from "react";
import { Card, Button, Form } from "react-bootstrap";
import axios from "axios";
import "./style.css";

export default class TasksComponent extends React.Component {
  constructor() {
    super();
    this.state = {
      tasks: [
        {
          name: "Buy beer and onions",
          description:
            "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolorum ex quis, quidem enim nobis laudantium dolores, debitis eos odio cum voluptas hic possimus impedit? Obcaecati rerum aut exercitationem expedita voluptatum?"
        }
      ],
      newTaskName: "",
      newTaskDescription: ""
    };
  }

  componentDidMount() {
    this.getTasks();
  }

  getTasks = () => {
    axios.get("/toDo").then(response => {
      console.log(response);
      this.setState({
        tasks: response.data
      });
    });
  };

  renderCard = (task, k) => {
    return (
      <Card key={k} style={{ width: "18rem" }}>
        <Card.Body>
          <Card.Title>{task.name}</Card.Title>
          <Card.Text>{task.description}</Card.Text>
        </Card.Body>
      </Card>
    );
  };

  addNewTask = () => {
    axios.post("/toDo", {
      name: this.state.newTaskName,
      description: this.state.newTaskDescription
    });
    this.getTasks();
  };

  onChange = e => {
    this.setState({
      [e.target.name]: e.target.value
    });
    console.log("tutaj:");
    console.log(this.state);
  };

  render() {
    let tasks = this.state.tasks
      .slice(0)
      .reverse()
      .map((val, index) => {
        return this.renderCard(val, index);
      });

    return (
      <div id="tasksPage">
        <div>{tasks}</div>
        <div>
          <Form>
            <Form.Group>
              <Form.Label>Task name:</Form.Label>
              <Form.Control
                name="newTaskName"
                onChange={this.onChange}
                type="text"
                placeholder="Enter task name"
              />
            </Form.Group>

            <Form.Group>
              <Form.Label>Task description:</Form.Label>
              <Form.Control
                name="newTaskDescription"
                onChange={this.onChange}
                as="textarea"
                rows="3"
              />
            </Form.Group>

            <Button
              disabled={this.state.newTaskName === ""}
              onClick={this.addNewTask}
              variant="primary"
            >
              Submit
            </Button>
          </Form>
        </div>
      </div>
    );
  }
}

//{this.state.tasks[0]}
