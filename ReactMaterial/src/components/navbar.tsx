import * as React from "react";
import {Link, NavLink} from "react-router-dom";

export class Navbar extends React.Component {
   componentDidMount() {
        $(".button-collapse").sideNav();
    }
    render() {
        return <nav className="">
            <div className="nav-wrapper orange">
                <a href="#" data-activates="mobile-open" className="button-collapse">
                    <i className="material-icons">menu</i>
                </a>
                <a href="#" className="brand-logo center">Sfiss1</a>
                <ul id="nav-mobile" className="left hide-on-med-and-down">
                    <li>
                        <NavLink to="/">Dashboard</NavLink>
                    </li>
                    <li>
                        <NavLink to="/exercises">Exercises</NavLink>
                    </li>
                    <li>
                        <NavLink to="/workouts">Workouts</NavLink>
                    </li>
                </ul>
                <ul className="side-nav">
                    <li>
                        <Link to="/">Dashboard</Link>
                    </li>
                    <li>
                        <Link to="/exercises">Exercises</Link>
                    </li>
                    <li>
                        <Link to="/workouts">Workouts</Link>
                    </li>
                </ul>
            </div>
        </nav>
    }
}
