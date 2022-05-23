export interface HeaderModel {
    titlePage: string;
    subTitle: string;
    buttons: ConfigureButtons;
}

export interface ConfigureButtons {
    color: string;
    description: string;
    action: () => void;
}