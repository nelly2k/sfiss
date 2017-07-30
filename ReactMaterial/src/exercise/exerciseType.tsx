import * as React from "react";
import {IMultiSelectItem} from "../components/MultiSelect"

export const ExerciseTypes:IMultiSelectItem[] =[
    {title: "Strength", id: "Strength"} as IMultiSelectItem,
    {title: "Stretch", id: "Stretch"} as IMultiSelectItem,
    {title: "Yoga", id: "Yoga"} as IMultiSelectItem,
    {title: "Cardio", id: "Cardio"} as IMultiSelectItem,
    {title: "Rest", id: "Rest"} as IMultiSelectItem,
]

export const EquipmentType:IMultiSelectItem[] = [
    {title: "Ball", id: "Ball"} as IMultiSelectItem,
    {title: "Barbell", id: "Barbell"} as IMultiSelectItem,
    {title: "Bosu", id: "Bosu"} as IMultiSelectItem,
    {title: "Dumbell", id: "Dumbell"} as IMultiSelectItem,
    {title: "Medicine Ball", id: "MedicineBall"} as IMultiSelectItem,
]