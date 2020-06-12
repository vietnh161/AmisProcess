import { PhaseEmployee } from '../_models/phase-employee';

export var phaseEmployeeData: PhaseEmployee[] = [
    {
        createdBy: "user user",
        createdTime: "Fri Jun 12 2020 15:35:19 GMT+0700 (Indochina Time)",
        employeeCode: "8",
        id: 1,
        phase: {
            canDel: false,
            description: "Phần này hiển thị mô tả",
            fields: [
                {
                    description: "test",
                    id: 1,
                    name: "Ngày bắt đầu",
                    options: [],
                    pharseId: 1,
                    required: true,
                    type: "Date",
                },
                {
                    id: 2, name: "Ngày kết thúc", description: "test test", type: "Date", options: [],
                    pharseId: 1,
                    required: true,
                },
                {
                    id: 12, name: "Asignee Select", description: "", type: "Asignee Select", options: [],
                    pharseId: 1,
                    required: true,
                },
                {
                    id: 10, name: "Check Box", description: "", type: "Check Box", 
                    options: [
                    { id: 1, value: "test checkbox 1" },
                    { id: 2, value: "test checkbox 2" },
                    { id: 3, value: "test checkbox 3" },
                    { id: 4, value: "test checkbox 4" }],
                    pharseId: 1,
                    required: true,
                },
                {
                    id: 11, name: "Radio Select", description: "", type: "Radio Select", options: [
                        { id: 5, value: "test radio 1"},
                        {id: 6, value: "test radio 2"}
                    ],
                    pharseId: 1,
                    required: true,
                }

            ],

            id: 1,
            isLastPhase: false,
            name: "Khởi tạo",
            personImplement: [],
            personImplementType: "all",
            process: {
                category: { id: 1, name: "Tài sản" },
                categoryId: 1,
                createdBy: "Nguyễn Văn An",
                createdTime: "2020/01/01 07:00",
                description: "Quy trình giúp cho việc xin cấp tài sản như...cho nhân viên",
                id: 1,
                name: "Quy trình xin cấp tài sản",
                status: "active",
                updatedBy: "Nguyễn Văn An",
                updatedTime: "2020/01/11 12:00",
            },
            processId: 1,
            serial: 1,
            timeImplement: 3,
            timeImplementType: "h",

        },
        phaseId: 1,
        updatedBy: "user user",
        updatedTime: "Fri Jun 12 2020 15:35:19 GMT+0700 (Indochina Time)"
    },
    

    
] 