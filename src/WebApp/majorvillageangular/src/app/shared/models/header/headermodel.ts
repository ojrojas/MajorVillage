export interface HeaderModel {
    titlePage: string;
    subTitle: string;
    buttons?: ConfigureButton[];
}

export interface ConfigureButton {
    styles?: string;
    icon?:string;
    description: string;
    type:string;
    action: () => void;
}