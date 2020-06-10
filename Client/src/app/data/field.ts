import { Field } from '../_models';

export var fieldData:Field[] = [
    {
        id: 1,
        name: 'Ngày bắt đầu',
        description: '',
        type: 'Date',
        options:[],
        required: true,
        pharseId: 1,
        
    },
    {
        id: 2,
        name: 'Ngày kết thúc',
        description: '',
        type: 'Date',
        required: true,
        pharseId: 1,
        options:[],
    },
    {
        id: 10,
        name: 'Check Box',
        description: '',
        type: 'Check Box',
        options:[
            {
                id: 1,
                value: 'test checkbox 1',
            },
            {
                id: 2,
                value: 'test checkbox 2',
            },
            {
                id: 3,
                value: 'test checkbox 3',
              
            },
            {
                id: 4,
                value: 'test checkbox 4',
               
            },


        ],
        required: true,
        pharseId: 1,
        
    },
    {
        id: 11,
        name: 'Radio Select',
        description: '',
        type: 'Radio Select',
        options:[
            {
                id: 5,
                value: 'test radio 1',
            },
            {
                id: 6,
                value: 'test radio 2',
            },
        ],
        required: true,
        pharseId: 1,
        
    },
    {
        id: 12,
        name: 'Asignee Select',
        description: '',
        type: 'Asignee Select',
        options:[],
        required: true,
        pharseId: 1,
        
    },
]