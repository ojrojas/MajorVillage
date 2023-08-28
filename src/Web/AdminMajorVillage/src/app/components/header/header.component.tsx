import React from "react"
import NavBarComponent from "./components/navbar.component";
import SearchComponent from "./components/search.component";

interface Props {
    onOpen: () => void;
}

const HeaderComponent: React.FC<Props> = ({ onOpen }) => {
   

    return (
       <React.Fragment>
             <NavBarComponent onOpen={onOpen} />
             <SearchComponent />
       </React.Fragment>
    );
}

export default HeaderComponent;