
import {IDropDownItem} from "../components/dropdown"
export enum MeasureType {
    Distance,
    Time,
    Rounds
}


export const MeasureTypeOptions : IDropDownItem[] = [
    {
        id: "distance",
        title: "distance",
        icon: "linear_scale"
    }, {
        id: "time",
        title: "time",
        icon: "access_time"
    },
    {
        id: "rounds",
        title: "rounds",
        icon: "format_list_numbered"
    }
]