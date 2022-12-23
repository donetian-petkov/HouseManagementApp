import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import {UserContext} from "../../contexts/userContext";
import {useContext} from "react";

/*import styles from './NavBar.module.css';*/
function NavBar() {

    const {getIsLoggedIn} = useContext(UserContext);
    const {getIsAdmin} = useContext(UserContext);


    return (
        <Navbar bg="light" expand="lg">
            <Container>
                <Navbar.Brand>Personal Management App</Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav"/>
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="me-auto">
                        <Nav.Link href="home">Home</Nav.Link>
                        {
                            getIsLoggedIn()
                                ? <div style={{display: "flex"}}>
                                    <Nav.Link href="calendar">Calendar</Nav.Link>
                                    <Nav.Link href="todolist">ToDoList</Nav.Link>
                                    <Nav.Link href="reminder">Reminders</Nav.Link>
                                    <Nav.Link href="notes">Notes</Nav.Link>
                                  </div>
                                : ''
                        }
                        {
                            getIsLoggedIn() && getIsAdmin()
                                ? <li><Nav.Link href="https://localhost:7244/admin" to={{pathname: "https://localhost:7244/admin"}} target="_blank">Admin Area</Nav.Link></li>
                                : ''
                        }
                        {
                            !getIsLoggedIn()
                                ? <li><Nav.Link href="/login">Login</Nav.Link></li>
                                : <li><Nav.Link href="/logout">Logout</Nav.Link></li>
                        }
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    );
}

export default NavBar;