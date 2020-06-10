import { Phase } from '../_models';

export var phaseData: Phase[] = [
    {
        id: 1,
        serial: 1,
        name: 'Khởi tạo',
        description: 'Phần này hiển thị mô tả',
        canDel:false,
        isLastPhase:false,
        timeImplementType:'h',
        timeImplement: 3,
        personImplementType:'all',
        personImplement: [],
        processId: 1,
        fields: [
            {
                id: 1,
                name: 'Ngày bắt đầu',
                description: 'test',
                type: 'Date',
                options:[],
                required: true,
                pharseId: 1,
                
            },
            {
                id: 2,
                name: 'Ngày kết thúc',
                description: 'test test',
                type: 'Date',
                options:[],
                required: true,
                pharseId: 1,
                
            },
            // {
            //     id: 1,
            //     name: 'Datetime',
            //     description: '',
            //     type: 'Datetime',
            //     options:[],
            //     required: true,
            //     pharseId: 1,
                
            // },
            // {
            //     id: 2,
            //     name: 'Time',
            //     description: '',
            //     type: 'Time',
            //     options:[],
            //     required: true,
            //     pharseId: 1,
                
            // },
            // {
            //     id: 1,
            //     name: 'Text',
            //     description: '',
            //     type: 'Text',
            //     options:[],
            //     required: true,
            //     pharseId: 1,
                
            // },
            // {
            //     id: 2,
            //     name: 'Long Text',
            //     description: '',
            //     type: 'Long Text',
            //     options:[],
            //     required: true,
            //     pharseId: 1,
                
            // },
            // {
            //     id: 2,
            //     name: 'Email',
            //     description: '',
            //     type: 'Email',
            //     options:[],
            //     required: true,
            //     pharseId: 1,
                
            // },
            // {
            //     id: 1,
            //     name: 'Number',
            //     description: '',
            //     type: 'Number',
            //     options:[],
            //     required: true,
            //     pharseId: 1,
                
            // },
            // {
            //     id: 2,
            //     name: 'Attachment',
            //     description: '',
            //     type: 'Attachment',
            //     options:[],
            //     required: true,
            //     pharseId: 1,
                
            // },
            {
                id: 12,
                name: 'Asignee Select',
                description: '',
                type: 'Asignee Select',
                options:[],
                required: true,
                pharseId: 1,
                
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
                
            }
        ],
    },
    {
        id: 2,
        serial: 4,
        name: 'Hoàn thành',
        description: 'Phần này hiển thị mô tả',
        canDel:false,
        isLastPhase:true,
        timeImplementType:'h',
        timeImplement: 3,
        personImplementType:'all',
        personImplement: [
           
        ],
        fields: [
            
        ],
        processId: 1,

    },
    {
        id: 3,
        serial: 2,
        name: 'Quản lý phê duyệt',
        description: 'Phần này hiển thị mô tả',
        canDel:true,
        isLastPhase:false,
        timeImplementType:'d',
        timeImplement: 3,
        personImplementType:'limit',
        personImplement: [
            {
                id: 1,
                employeeCode:'1',
                firstName: 'Quang',
                lastName: 'Lê Thanh',
        
            },
            {
                id: 2,
                employeeCode:'2',
                firstName: 'Hà',
                lastName: 'Hồ Quang',
            },
            {
                id: 3,
                employeeCode:'3',
                firstName: 'Bảo',
                lastName: 'Lê Ngọc',
            },
            {
                id: 4,
                employeeCode:'4',
                firstName: 'Test',
                lastName: 'Lê Ngọc',
            },
        ],
        fields: [

        ],
        processId: 1,

    },
    {
        id: 4,
        serial: 3,
        name: 'Giám đốc phê duyệt',
        description: 'Phần này hiển thị mô tả',
        canDel:true,
        isLastPhase:false,
        timeImplementType:'m',
        timeImplement: 3,
        personImplementType:'all',
        personImplement: [

        ],
        fields: [
            
        ],
        processId: 1,

    },
     
]