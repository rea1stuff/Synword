import React from "react";
import Header from "./Header";

class HeaderContainer extends React.Component {
    render() {
        const {
            windowWidth,
            moveToMainScreen
        } = this.props;

        let title;
        
        if(windowWidth >= 550) {
            title = "Уникальность текста равна";
        }
        else {
            title = "Уникальность текста<br>равна"
        }
        return (
            <Header 
            title={title}
            moveToMainScreen
            ={moveToMainScreen}/>
        );
    }
}

export default HeaderContainer;