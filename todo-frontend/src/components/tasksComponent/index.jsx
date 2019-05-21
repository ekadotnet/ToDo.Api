import React from "react";
import { Card, Button } from "react-bootstrap";

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
      ]
    };
  }

  render() {
    return (
      <Card style={{ width: "18rem" }}>
        <Card.Body>
          <Card.Title>{this.state.tasks[0].name}</Card.Title>
          <Card.Text>{this.state.tasks[0].description}</Card.Text>
          <Button variant="primary">Click</Button>
        </Card.Body>
      </Card>
    );
  }
}

//{this.state.tasks[0]}
