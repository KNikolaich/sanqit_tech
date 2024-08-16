const createElement = <T extends Element>(template: string) =>{
    const div = document.createElement("div")
    div.innerHTML = template.trim();
    return div.firstChild as T;
}

const render = (element: Element, container: Element) => {
    container.appendChild(element);
}

export { createElement, render };