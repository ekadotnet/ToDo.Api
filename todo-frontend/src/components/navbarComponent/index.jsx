import React from "react";
import { Navbar, Nav, NavDropdown, FormGroup } from "react-bootstrap";

export default class NavbarComponent extends React.Component {
  render() {
    return (
      <Navbar bg="dark" variant="dark">
        <Navbar.Brand href="/">ToDo</Navbar.Brand>
        <Nav className="mr-auto">
          <Nav.Link href="/tasks">Tasks</Nav.Link>
        </Nav>
      </Navbar>
    );
  }
}
